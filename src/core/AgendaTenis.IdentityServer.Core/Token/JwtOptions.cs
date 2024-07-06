using Microsoft.IdentityModel.Tokens;

namespace AgendaTenis.IdentityServer.Core.Token;

public class JwtOptions
{
    public SigningCredentials SigningCredentials { get; set; }
    public int ExpiracaoEmSegundos { get; set; }
}
