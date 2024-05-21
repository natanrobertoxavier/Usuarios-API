using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Usuarios.API.Data.Dtos;
using Usuarios.API.Models;
using Usuarios.API.Service;

namespace Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly CadastroService _cadastroService;

    public UsuarioController(
        CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsusario(
        CriarUsuarioDto dto)
    {
        await _cadastroService.CadastraAsync(dto);
        
        return Ok("Usuário Cadastrado");
    }
}
