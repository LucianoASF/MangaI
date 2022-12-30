namespace MangaI.Dtos;

public class MatriculaResposta
{
    public int Id { get; set; }
    public UsuarioResposta Usuario { get; set; }
    public int UsuarioId { get; set; }
    public MatrizResposta Matriz { get; set; }
    public int MatrizId { get; set; }
    public int AnoComeco { get; set; }
    public int? AnoFim { get; set; }
}
