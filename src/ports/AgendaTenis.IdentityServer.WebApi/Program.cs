using AgendaTenis.IdentityServer.Core.Aplicacao.CriarConta;
using AgendaTenis.IdentityServer.Core.Aplicacao.GerarToken;
using AgendaTenis.WebApi.ConfiguracaoDeServicos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegistrarIdentity(builder.Configuration);
builder.Services.RegistrarSwagger();

builder.Services.AddScoped<CriarContaHandler>();
builder.Services.AddScoped<GerarTokenHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
