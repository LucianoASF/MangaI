using System.ComponentModel.DataAnnotations;

namespace MangaI.Dtos;

public class TurmaCriarAtualizarRequisicao
{
    [Required]
    public int Ano { get; set; }
    public int DisciplinaId { get; set; }
}
