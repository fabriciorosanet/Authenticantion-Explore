namespace Authentication_Explore.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public TipoPermissaoSistema PermissaoSistema { get; set; }
}

public enum TipoPermissaoSistema
{
    //categorias fixas do sistema
    Administrador,
    UsuarioEspecial,
    UsuarioBasico,
    UsuarioLimitado,
}

//Simula em memória banco de dados de usuário
public static class ListaUsuario
{
    public static IList<Usuario> Usuarios {get; set; }
}


