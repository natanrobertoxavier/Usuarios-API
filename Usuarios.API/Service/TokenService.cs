using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Usuarios.API.Models;

namespace Usuarios.API.Service;

public class TokenService
{
    public string GenerateToken(Usuario usuario)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ebf4973807d945c0aea0ee558fa0bd0d6e17f014bc60c93886987d0523be1f4c"));

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
