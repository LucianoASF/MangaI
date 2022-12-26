namespace MangaI.Dtos;

public class AvaliacaoResposta
{
    public int Id { get; set; }
    public int Nome { get; set; }
    public Decimal Valor { get; set; }
    public DateTime Data { get; set; }

    public int TurmaId { get; set; }
    public TurmaResposta Turma { get; set; }

}
