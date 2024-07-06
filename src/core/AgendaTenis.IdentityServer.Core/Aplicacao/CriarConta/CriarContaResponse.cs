using AgendaTenis.Notificacoes;

namespace AgendaTenis.IdentityServer.Core.Aplicacao.CriarConta;

public class CriarContaResponse
{
    public int? Id { get; set; }
    public List<Notificacao> Notificacoes { get; set; }
}
