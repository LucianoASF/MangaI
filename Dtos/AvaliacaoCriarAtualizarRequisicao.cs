using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class AvaliacaoCriarAtualizarRequisicao
{

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(45, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [Range(1, 100, ErrorMessage = "Duração deve ser entre {1} e {2}")]
    public Decimal Valor { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int TurmaId { get; set; }

}
