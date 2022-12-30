
using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class UsuarioCriarRequisicao
{

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(45, MinimumLength = 4, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(45, MinimumLength = 4, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(60, MinimumLength = 4, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(25, MinimumLength = 8, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string RG { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Sexo { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int PerfilId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int EnderecoId { get; set; }



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
