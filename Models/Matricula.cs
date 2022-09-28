using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Matricula
{
    [Required]
    [Column(TypeName = "Decimal(13,2)")]

    
    public Decimal NotaObtida { get; set; }
}
