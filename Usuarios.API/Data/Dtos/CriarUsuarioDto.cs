using System.ComponentModel.DataAnnotations;

namespace Usuarios.API.Data.Dtos;

public class CriarUsuarioDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [Required]
    [Compare("Senha")]
    public string ConfirmarSenha { get; set; }
}
