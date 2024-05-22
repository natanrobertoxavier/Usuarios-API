using Microsoft.AspNetCore.Mvc;
using Usuarios.API.Data.Dtos;
using Usuarios.API.Service;

namespace Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(
        UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsusario(
        CriarUsuarioDto dto)
    {
        await _usuarioService.CadastraAsync(dto);
        
        return Ok("Usuário Cadastrado");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUsusario(
        LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
                
        return Ok(token);
    }
}
