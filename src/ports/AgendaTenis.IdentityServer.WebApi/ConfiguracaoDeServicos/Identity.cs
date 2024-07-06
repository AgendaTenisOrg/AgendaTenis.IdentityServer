using AgendaTenis.IdentityServer.Core.AcessoDados;
using AgendaTenis.IdentityServer.Core.AcessoDados.Repositorios;
using AgendaTenis.IdentityServer.Core.Dominio;
using AgendaTenis.IdentityServer.Core.Token;
using AgendaTenis.IdentityServer.Core.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AgendaTenis.WebApi.ConfiguracaoDeServicos;

public static class Identity
{
    public static void RegistrarIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIdentityRepositorio, IdentityRepositorio>();
        services.AddScoped<ISenhaHasher<UsuarioEntity>, SenhaHasher<UsuarioEntity>>();
        services.AddScoped<IPasswordHasher<UsuarioEntity>, PasswordHasher<UsuarioEntity>>();

        var section = configuration.GetSection(nameof(JwtOptions));
        var chave = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(section["ChaveSecreta"]));

        services.AddScoped(c => new JwtOptions()
        {
            ExpiracaoEmSegundos = int.Parse(section["ExpiracaoEmSegundos"]),
            SigningCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256)
        });

        services.AddScoped<GeradorDeToken>();

        services.AddDbContext<IdentityDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("Identity")));

    }
}
