using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class ConteudoCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    [MinLength(5, ErrorMessage = "O mínimo de caracteres permidos são {1}")]
    public string Tema { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public DateTime Dia { get; set; }

    public int TurmaId { get; set; }

}
