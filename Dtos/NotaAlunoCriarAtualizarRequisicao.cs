using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Dtos;

public class NotaAlunoCriarAtualizarRequisicao
{

    [Required]
    [Column(TypeName = "decimal(13,2)")]
    public decimal NotaObtida { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int MatriculaPorTurmaId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int AvaliacaoId { get; set; }
}
