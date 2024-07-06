using AgendaTenis.IdentityServer.Core.AcessoDados.Mapeamentos;
using AgendaTenis.IdentityServer.Core.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AgendaTenis.IdentityServer.Core.AcessoDados;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    public DbSet<UsuarioEntity> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMapping());

        base.OnModelCreating(modelBuilder);
    }
}
