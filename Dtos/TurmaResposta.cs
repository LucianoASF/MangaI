namespace MangaI.Dtos;

public class TurmaResposta
{
    public int Id { get; set; }
    public int Ano { get; set; }
    public DisciplinaResposta Disciplina { get; set; }
    public int DisciplinaId { get; set; }
}
