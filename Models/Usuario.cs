namespace MangaI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "varchar(25)")]
    public string CPF { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string RG { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [Column(TypeName = "varchar(25)")]
    public string Sexo { get; set; }
}
