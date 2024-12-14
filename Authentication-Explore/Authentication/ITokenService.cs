using Authentication_Explore.Entities;

namespace Authentication_Explore.Authemtication;

public interface ITokenService
{
    public string GetToken(Usuario usuario);
}