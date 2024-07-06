using AgendaTenis.IdentityServer.Core.Dominio;

namespace AgendaTenis.IdentityServer.Core.AcessoDados.Repositorios;

public interface IIdentityRepositorio
{
    Task<bool> EmailJaExiste(string email);
    Task<Guid> Inserir(UsuarioEntity entity);
    Task<UsuarioEntity> ObterUsuario(string email);
}
