using AgendaTenis.IdentityServer.Core.Aplicacao.CriarConta;
using AgendaTenis.IdentityServer.Core.Aplicacao.GerarToken;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTenis.IdentityServer.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    [HttpPost("CriarConta")]
    public async Task<IActionResult> CriarConta([FromServices] CriarContaHandler handler, CriarContaCommand command)
    {
        var response = await handler.Handle(command, new CancellationToken());
        return Ok(response);
    }

    [HttpPost("GerarToken")]
    public async Task<IActionResult> GerarToken([FromServices] GerarTokenHandler handler, GerarTokenCommand command)
    {
        var response = await handler.Handle(command, new CancellationToken());
        return Ok(response);
    }
}
