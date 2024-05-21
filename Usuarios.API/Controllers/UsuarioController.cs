using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Usuarios.API.Data.Dtos;
using Usuarios.API.Models;

namespace Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioController(
        IMapper mapper, 
        UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsusario(
        CriarUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

        if (result.Succeeded)
            return Ok("Usuário Cadastrado");

        string errors = string.Empty;

        foreach (var error in result.Errors)
        {
            if (!string.IsNullOrEmpty(errors))
                errors += "|";

            errors += $" {error.Code}";
        }

        throw new ApplicationException($"Falha ao cadastrar usuário! ERROR: {errors}");
    }
}
