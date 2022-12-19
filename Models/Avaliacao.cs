using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Avaliacao
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public int Nome { get; set; }

    [Required]
    [Column(TypeName = "Decimal(13,2)")]
    public Decimal Valor { get; set; }

    [Required]
    public DateTime Data { get; set; }


    //Propriedade de Navegação Avaliação 1 : N NotaAluno
    public List<NotaAluno> NotaAlunos { get; set; }



    //Propriedade de Navegação Avaliação N : 1 Turma

    public Turma Turma { get; set; }

    //chave estrangeira Avaliação N : 1 Turma

    public int TurmaId { get; set; }

}
