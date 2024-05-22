using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Usuarios.API.Data.Dtos;
using Usuarios.API.Models;

namespace Usuarios.API.Service;

public class UsuarioService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signManager;
    private readonly TokenService _tokenService;

    public UsuarioService(
        IMapper mapper,
        UserManager<Usuario> userManager,
        SignInManager<Usuario> signManager,
        TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signManager = signManager;
        _tokenService = tokenService;
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

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        var resultado = await _signManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException($"Usuário não autenticado!");
        }

        var usuario = _signManager.UserManager.Users.FirstOrDefault(o => o.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.GenerateToken(usuario);

        return token;
    }
}
