namespace MangaI.Dtos;

public class FrequenciaResposta
{

    public int Id { get; set; }
    public bool Presente { get; set; }

    public int ConteudoId { get; set; }
    public int MatriculaId { get; set; }

     public ConteudoResposta Conteudo { get; set; }
     
    //  public MatriculaResposta Matricula { get; set; }
}
