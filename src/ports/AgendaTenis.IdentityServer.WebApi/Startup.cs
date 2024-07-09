using AgendaTenis.IdentityServer.Core.AcessoDados;
using AgendaTenis.IdentityServer.Core.Aplicacao.CriarConta;
using AgendaTenis.IdentityServer.Core.Aplicacao.GerarToken;
using AgendaTenis.WebApi.ConfiguracaoDeServicos;
using Microsoft.EntityFrameworkCore;

namespace AgendaTenis.IdentityServer.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.RegistrarIdentity(Configuration);
        services.RegistrarSwagger();

        services.AddScoped<CriarContaHandler>();
        services.AddScoped<GerarTokenHandler>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IdentityDbContext identityDbContext)
    {
        Console.WriteLine(env.EnvironmentName);

        if (env.IsDevelopment() || env.EnvironmentName == "Container")
        {
            // Em ambiente de desenvolvimento a aplicação já aplica as migrations para deixar o banco de dados pronto
            identityDbContext.Database.Migrate();

            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
