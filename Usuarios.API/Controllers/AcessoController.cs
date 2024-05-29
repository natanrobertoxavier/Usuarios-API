using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomelo.EntityFrameworkCore.MySql.Query.ExpressionTranslators.Internal;

namespace Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class AcessoController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult Get()
    {
        return Ok("Acesso Permitido");
    }
}
