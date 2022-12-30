
using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class MatriculaCriarAtualizarRequisicao
{

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int MatrizId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int AnoComeco { get; set; }

    public int? AnoFim { get; set; }

}
