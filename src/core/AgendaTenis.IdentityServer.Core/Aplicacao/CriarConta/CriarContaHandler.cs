using AgendaTenis.IdentityServer.Core.AcessoDados.Repositorios;
using AgendaTenis.IdentityServer.Core.Dominio;
using AgendaTenis.IdentityServer.Core.Utils;

namespace AgendaTenis.IdentityServer.Core.Aplicacao.CriarConta;

public class CriarContaHandler
{
    private readonly IIdentityRepositorio _identityRepositorio;
    private readonly ISenhaHasher<UsuarioEntity> _hasher;

    public CriarContaHandler(
        IIdentityRepositorio identityRepositorio,
        ISenhaHasher<UsuarioEntity> hasher)
    {
        _identityRepositorio = identityRepositorio;
        _hasher = hasher;
    }

    public async Task<CriarContaResponse> Handle(CriarContaCommand request, CancellationToken cancellationToken)
    {
        var commandValidator = new CriarContaCommandValidator(_identityRepositorio);
        var resultadoValidacao = await commandValidator.ValidateAsync(request);

        if (!resultadoValidacao.IsValid)
            return new CriarContaResponse()
            {
                Notificacoes = resultadoValidacao.Errors.ToNotificacao()
            };

        var entity = new UsuarioEntity(request.Email, request.Senha, _hasher);
        var id = await _identityRepositorio.Inserir(entity);

        return new CriarContaResponse()
        {
            Id = id
        };
    }
}
