using AgendaTenis.IdentityServer.Core.Aplicacao.CriarConta;
using AgendaTenis.IdentityServer.Core.Aplicacao.GerarToken;
using AgendaTenis.IdentityServer.WebApi;
using AgendaTenis.WebApi.ConfiguracaoDeServicos;
using Microsoft.AspNetCore.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
