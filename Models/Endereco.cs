using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MangaI.Models;

public class Endereco
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Rua { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Cep { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Bairro { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Cidade { get; set; }

}
