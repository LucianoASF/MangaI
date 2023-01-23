using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class TelefoneCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    [MinLength(8, ErrorMessage = "O mínimo de números permidos são {1}")]
    public string Numero { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int UsuarioId { get; set; }
}
