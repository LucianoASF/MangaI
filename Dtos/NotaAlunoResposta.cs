namespace MangaI.Dtos;

public class NotaAlunoResposta
{
    public int Id { get; set; }

    public decimal NotaObtida { get; set; }

    public int MatriculaPorTurmaId { get; set; }

    public int AvaliacaoId { get; set; }

    public MatriculaPorTurmaResposta MatriculaPorTurma { get; set; }

    public AvaliacaoResposta Avaliacao { get; set; }
}

