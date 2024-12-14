using System.Text;
using Authentication_Explore.Authemtication;
using Authentication_Explore.Authentication;
using Authentication_Explore.Entities;
using Authentication_Explore.Interfaces;
using Authentication_Explore.Logging;
using Authentication_Explore.Repositories;
using Authentication_Explore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IAlunoRepository, AlunoRepository>();
builder.Services.AddKeyedScoped<IAlunoService, AlunoService>("AlunoKeyed");
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration()));

// Configuração de autenticação

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
    
builder.Services.AddSwaggerGen( c =>
    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme(
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
        
    }));
    
    
    
    
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}