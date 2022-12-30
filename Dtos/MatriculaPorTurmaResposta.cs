using MangaI.Models;

namespace MangaI.Dtos;

public class MatriculaPorTurmaResposta
{
    public decimal? NotaFinal { get; set; }
    public int MatriculaId { get; set; }
    public MatriculaResposta Matricula { get; set; }
    public int TurmaId { get; set; }
    public TurmaResposta Turma { get; set; }
}
