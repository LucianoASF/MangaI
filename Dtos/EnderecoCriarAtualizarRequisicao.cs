using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class EnderecoCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    [StringLength(45, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Rua { get; set; }

    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    // [RegularExpression("#####-###")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    [StringLength(45, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "Esse campo não pode estar vazio!")]
    [StringLength(45, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int UsuarioId { get; set; }

}
