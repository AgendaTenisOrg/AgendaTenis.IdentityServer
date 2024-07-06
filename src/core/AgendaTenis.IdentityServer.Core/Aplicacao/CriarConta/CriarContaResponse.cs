using AgendaTenis.Notificacoes;

namespace AgendaTenis.IdentityServer.Core.Aplicacao.CriarConta;

public class CriarContaResponse
{
    public Guid? Id { get; set; }
    public List<Notificacao> Notificacoes { get; set; }
}
