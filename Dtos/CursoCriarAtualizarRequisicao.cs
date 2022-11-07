using System.ComponentModel.DataAnnotations;

namespace Mangal.Dtos;

public class CursoCriarAtualizarRequisicao
{

  [Required(ErrorMessage = "{0} é obrigatório")]
  [StringLength(100,
   MinimumLength = 3,
   ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]

    public string Nome { get; set; }

}
