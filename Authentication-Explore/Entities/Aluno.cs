namespace Authentication_Explore.Entities;

public class Aluno
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string? Idade { get; set; }
    public string Endereco { get; set; } = string.Empty; //inicializa seu valor padrão como string vazia
}