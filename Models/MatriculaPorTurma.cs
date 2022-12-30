using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class MatriculaPorTurma
{
    [Required]
    public int Id { get; set; }

    [Column(TypeName = "Decimal(13,2)")]

    public Decimal? NotaFinal { get; set; }

    //propriedade de Navegação Matricula 1 : N MatriculaPorTurma

    public Matricula Matricula { get; set; }

    //Chave Estrangeira Matricula 1 : N MatriculaPorTurma

    public int MatriculaId { get; set; }

    //propriedade de Navegação Turma 1 : N MatriculaPorTurma

    public Turma Turma { get; set; }

    //Chave Estrangeira Turma 1 : N MatriculaPorTurma

    public int TurmaId { get; set; }

    //Propriedade de Navegação Frequencia N : 1 MatriculaPorTurma

    public List<Frequencia> Frequencias { get; set; }

    //Propriedade de Navegação NotaAluno N : 1 MatriculaPorTurma

    public List<NotaAluno> NotaAlunos { get; set; }
}
