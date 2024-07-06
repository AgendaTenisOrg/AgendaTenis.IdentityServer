using AgendaTenis.IdentityServer.Core.Dominio;

namespace AgendaTenis.IdentityServer.Core.AcessoDados.Repositorios;

public interface IIdentityRepositorio
{
    Task<bool> EmailJaExiste(string email);
    Task<int> Inserir(UsuarioEntity entity);
    Task<UsuarioEntity> ObterUsuario(string email);
}
