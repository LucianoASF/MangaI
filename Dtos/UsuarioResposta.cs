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
    public int EnderecoId { get; set; }
    public PerfilResposta Perfil { get; set; }
    public EnderecoResposta Endereco { get; set; }


    // public EnderecoResposta Endereco { get; set; }
    // public List<PerfilResposta> Perfis { get; set; }
}



/*
public class EnderecoResposta
{
    public int Id { get; set; }
    public string Rua { get; set; }
    public string Cep { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
}

public class PerfilResposta
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
*/