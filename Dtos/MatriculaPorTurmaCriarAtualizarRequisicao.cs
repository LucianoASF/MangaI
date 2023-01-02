using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class MatriculaPorTurmaCriarAtualizarRequisicao
{
    [Range(1, 100, ErrorMessage = "A nota deve estar entre {1} e {2}")]
    public Decimal? NotaFinal { get; set; }

    [Required]
    public int MatriculaId { get; set; }

    [Required]
    public int TurmaId { get; set; }
}
