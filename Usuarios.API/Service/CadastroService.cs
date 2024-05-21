using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Usuarios.API.Data.Dtos;
using Usuarios.API.Models;

namespace Usuarios.API.Service;

public class CadastroService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;

    public CadastroService(
        IMapper mapper,
        UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }


    public async Task CadastraAsync(CriarUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

        if (!result.Succeeded)
        {
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
}
