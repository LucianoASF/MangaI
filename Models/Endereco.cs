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
    [Column(TypeName = "varchar(20)")]
    public string Cep { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Bairro { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Cidade { get; set; }

    //Propriedade de Navegação Endereco 1 : 1 Usuario

    public Usuario Usuario { get; set; }

    //Chave Estrangeira Usuario 1 : 1 Endereco

    public int UsuarioId { get; set; }
}
