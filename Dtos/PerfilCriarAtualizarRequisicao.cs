using System.ComponentModel.DataAnnotations;
namespace MangaI.Dtos;

public class PerfilCriarAtualizarRequisicao
{

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(45, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }
}
