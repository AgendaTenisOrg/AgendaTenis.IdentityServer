using AgendaTenis.Notificacoes;

namespace AgendaTenis.IdentityServer.Core.Aplicacao.GerarToken;

public class GerarTokenResponse
{
    public string Token { get; set; }
    public List<Notificacao> Notificacoes { get; set; }
}
