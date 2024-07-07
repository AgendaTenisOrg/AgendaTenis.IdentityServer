using AgendaTenis.Notificacoes.Core;

namespace AgendaTenis.IdentityServer.Core.Aplicacao.CriarConta;

public class CriarContaResponse
{
    public int? Id { get; set; }
    public List<Notificacao> Notificacoes { get; set; }
}
