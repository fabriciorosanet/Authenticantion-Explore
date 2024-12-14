using Authentication_Explore.Entities;

namespace Authentication_Explore.Middleware;

public class NovoMiddleware
{
    private readonly RequestDelegate _next;

    public NovoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ListaUsuario.Usuarios =
        [
            new Usuario
            {
                Id = 1, Username = "Admin", Password = "Admin123", PermissaoSistema = TipoPermissaoSistema.Administrador
            },
            new Usuario
            {
                Id = 2, Username = "fabriciorosanet", Password = "123rosa",
                PermissaoSistema = TipoPermissaoSistema.UsuarioEspecial
            },
            new Usuario
            {
                Id = 3, Username = "Bianca", Password = "meAma123",
                PermissaoSistema = TipoPermissaoSistema.UsuarioBasico
            },
            new Usuario
            {
                Id = 4, Username = "Felipe", Password = "irmao123",
                PermissaoSistema = TipoPermissaoSistema.UsuarioLimitado
            }
        ];
        
        // Chama o próximo delegate/middleware no pipeline
        await _next(context);
    }
}

public static class NovoMiddlewareExtensions
{
    public static IApplicationBuilder UseNovoMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<NovoMiddleware>();
    }
}