namespace MangaI.Dtos;

public class ConteudoResposta
{
    public int Id { get; set; }
    public string Tema { get; set; }
    public DateTime Dia { get; set; }

    public int TurmaId { get; set; }
    public TurmaResposta Turma { get; set; }

}
