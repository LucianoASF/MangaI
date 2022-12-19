namespace MangaI.Dtos;

public class TelefoneResposta
{
    public string Id { get; set; }
    public string Numero { get; set; }


    public int UsuarioId { get; set; }
    public UsuarioResposta Usuario { get; set; }

}
