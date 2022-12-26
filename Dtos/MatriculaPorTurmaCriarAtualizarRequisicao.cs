using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class MatriculaPorTurmaCriarAtualizarRequisicao
{
    public Decimal? NotaFinal { get; set; }

    [Required]
    public int MatriculaId { get; set; }

    [Required]
    public int TurmaId { get; set; }
}
