namespace MangaI.Dtos;
using System.ComponentModel.DataAnnotations;

public class DisciplinaCriarAtualizarRequisicao
{

    [Required(ErrorMessage = "{0} é obrigatório")]
    [StringLength(100,
     MinimumLength = 3,
     ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]

    public string Nome { get; set; }



    [Required(ErrorMessage = "Duração é obrigatório")]
    [Range(1, 1000, ErrorMessage = "Duração deve ser entre {1} e {2}")]
    public int CargaHoraria { get; set; }

    public List<MatrizResposta> Matrizes { get; set; }

}
