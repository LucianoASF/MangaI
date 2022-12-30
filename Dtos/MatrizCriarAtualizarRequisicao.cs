using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class MatrizCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    public int Versao { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int CursoId { get; set; }

    public List<DisciplinaResposta> Disciplinas { get; set; }

}
