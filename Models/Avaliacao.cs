using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Avaliacao
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName = "Decimal(13,2)")]
    public Decimal Valor { get; set; }

}
