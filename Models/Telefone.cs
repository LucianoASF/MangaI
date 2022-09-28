namespace MangaI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Telefone
{
    [Required]
    public string Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Numero { get; set; }
}