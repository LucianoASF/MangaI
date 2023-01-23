namespace MangaI.Dtos;

public class UsuarioResposta
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public int PerfilId { get; set; }
    public PerfilResposta Perfil { get; set; }

}
