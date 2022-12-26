using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class ConteudoCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [MinLength(5, ErrorMessage = "O mínimo de caracteres permidos são {1}")]
    public string Tema { get; set; }
    [Required(ErrorMessage = "Campo Obrigatorio")]
    public DateTime Dia { get; set; }

     public int TurmaId { get; set; }

}
