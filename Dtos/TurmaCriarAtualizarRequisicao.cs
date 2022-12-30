using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class TurmaCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int DisciplinaId { get; set; }
}
