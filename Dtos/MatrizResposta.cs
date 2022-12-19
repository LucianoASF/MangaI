namespace MangaI.Dtos;

public class MatrizResposta
{
    public int Id { get; set; }
    public int Versao { get; set; }
    public int CursoId { get; set; }
    public CursoResposta Curso { get; set; }
}
