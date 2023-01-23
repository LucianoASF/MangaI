using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class UsuarioLoginRequisicao
{
    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    [Required]
    [StringLength(60)]
    public string Senha { get; set; }
}
