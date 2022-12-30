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
    [Column(TypeName = "varchar(60)")]
    public string Senha { get; set; }

    [Required]
    [Column(TypeName = "varchar(14)")]
    public string CPF { get; set; }

    [Required]
    [Column(TypeName = "varchar(25)")]
    public string RG { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [Column(TypeName = "varchar(25)")]
    public string Sexo { get; set; }

    //Propriedade de Navegação Usuario 1 : N Telefone

    public List<Telefone> Telefones { get; set; }

    //Propriedade de Navegação Usuario N : 1 Perfil

    public Perfil Perfil { get; set; }

    //Chave Estrangeira Usuario N : 1 Perfil

    public int PerfilId { get; set; }

    //Propriedade de Navegação Usuario N : 1 Endereco
    public Endereco Endereco { get; set; }

    //Chave Estrangeira Usuario N : 1 Endereco

    public int EnderecoId { get; set; }

    //Propriedade de Navegação Usuario 1 : N Matricula
    public List<Matricula> Matriculas { get; set; }


}
