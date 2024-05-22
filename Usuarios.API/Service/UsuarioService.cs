﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Usuarios.API.Data.Dtos;
using Usuarios.API.Models;

namespace Usuarios.API.Service;

public class UsuarioService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signManager;

    public UsuarioService(
        IMapper mapper,
        UserManager<Usuario> userManager,
        SignInManager<Usuario> signManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signManager = signManager;
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

    public async Task Login(LoginUsuarioDto dto)
    {
        var resultado = await _signManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException($"Usuário não autenticado!");
        }
    }
}