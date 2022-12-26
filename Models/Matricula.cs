using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Matricula
{
    [Required]
    public int Id { get; set; }

    [Column(TypeName = "Decimal(13,2)")]


    public Decimal NotaFinal { get; set; }

    //Propriedade de Navegação Matricula N : 1 Usuario

    public Usuario Usuario { get; set; }

    //Chave Estrangeira Matricula N : 1 Usuario

    public int UsuarioId { get; set; }


    //propriedade de Navegação Matricula 1 : N MatriculaPorTurma

    public List<MatriculaPorTurma> MatriculaPorTurmas { get; set; }

    //propriedade de Navegação Matriz 1 : N Matricula

    public Matriz Matriz { get; set; }

    //Chave Estrangeira Matricula N : 1 Matriz

    public int MatrizId { get; set; }


}
