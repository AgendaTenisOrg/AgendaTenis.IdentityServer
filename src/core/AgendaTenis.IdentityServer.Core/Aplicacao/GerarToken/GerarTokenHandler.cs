using AgendaTenis.IdentityServer.Core.AcessoDados.Repositorios;
using AgendaTenis.IdentityServer.Core.Dominio;
using AgendaTenis.IdentityServer.Core.Token;
using AgendaTenis.IdentityServer.Core.Utils;
using AgendaTenis.Notificacoes.Core;
using AgendaTenis.Notificacoes.Core.Enums;
using System.Security.Claims;

namespace AgendaTenis.IdentityServer.Core.Aplicacao.GerarToken;

public class GerarTokenHandler
{
    private readonly IIdentityRepositorio _identityRepositorio;
    private readonly ISenhaHasher<UsuarioEntity> _hasher;
    private readonly GeradorDeToken _geradorDeToken;

    public GerarTokenHandler(IIdentityRepositorio identityRepositorio, ISenhaHasher<UsuarioEntity> hasher, GeradorDeToken geradorDeToken)
    {
        _identityRepositorio = identityRepositorio;
        _hasher = hasher;
        _geradorDeToken = geradorDeToken;
    }

    public async Task<GerarTokenResponse> Handle(GerarTokenCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _identityRepositorio.ObterUsuario(request.Email);

        if (usuario is null)
            return CriarResponseErro();

        var resultadoHash = _hasher.VerificarHashSenha(usuario, usuario.Senha, request.Senha);

        if (resultadoHash)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Id.ToString())
            };

            var token = _geradorDeToken.Gerar(claims);
            return new GerarTokenResponse()
            {
                Token = token
            };
        }
        else
        {
            return CriarResponseErro();
        }
    }

    private GerarTokenResponse CriarResponseErro()
    {
        return new GerarTokenResponse()
        {
            Notificacoes = new List<Notificacao>()
            {
                new Notificacao()
                {
                    Mensagem = "E-mail ou senha incorretos",
                    Tipo = TipoNotificacaoEnum.Erro
                }
            }
        };
    }
}
