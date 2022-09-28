using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Matriz
{
    [Required]
    public int Id { get; set; }

    [Required]

    public int Versao { get; set; }

    //propriedade de Navegação M-n

    public List<Disciplina> Disciplinas { get; set; }
}
