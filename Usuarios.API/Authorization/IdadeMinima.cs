using Microsoft.AspNetCore.Authorization;

namespace Usuarios.API.Authorization;

public class IdadeMinima : IAuthorizationRequirement
{
    public int Idade { get; set; }

    public IdadeMinima(int idade)
    {
        Idade = idade;
    }
}
