
namespace MangaI.Dtos;

public class UsuarioCriarRequisicao
{

    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public int PerfilId { get; set; }
    public int EnderecoId { get; set; }
    public int MatrizId { get; set; }

    //  public EnderecoCriarAtualizarRequisicao Endereco { get; set; }

}



/*public class EnderecoCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    public string Rua { get; set; }



    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    public string Cep { get; set; }



    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Tamanho de caracteres inválidos!")]
    public string Bairro { get; set; }



    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Tamanho de caracteres inválidos!")]
    public string Cidade { get; set; }

}

*/
