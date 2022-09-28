using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangal.Models;

public class NotaAluno
{

    [Column(TypeName = "decimal(13,2)")]
    public decimal NotaObtida { get; set; }
}
