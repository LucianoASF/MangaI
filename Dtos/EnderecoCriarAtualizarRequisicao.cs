using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class EnderecoCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    public string Rua { get; set; }

    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    // [RegularExpression("#####-###")]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Tamanho de caracteres inválidos!")]

    public string Bairro { get; set; }

    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Tamanho de caracteres inválidos!")]
    public string Cidade { get; set; }

}
