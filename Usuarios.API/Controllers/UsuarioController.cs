using Microsoft.AspNetCore.Mvc;
using Usuarios.API.Data.Dtos;

namespace Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public IActionResult CadastraUsusario(
        CriarUsuarioDto dto)
    {
        throw new NotImplementedException();
    }
}
