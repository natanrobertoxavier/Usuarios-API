using Microsoft.AspNetCore.Identity;

namespace Usuarios.API.Models;

public class Usuario : IdentityUser
{
    public Usuario() : base() { }

    public DateTime DataNascimento { get; set; }
}
