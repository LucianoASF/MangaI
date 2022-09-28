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

    //Propriedade de Navegação Matricula 1 : N NotaAluno
    public List<NotaAluno> NotasAlunos { get; set; }

    //Propriedade de Navegação Matricula 1 : N Frequencia

    public List<Frequencia> Frequencias { get; set; }

    //Propriedade de Navegação Matricula N : 1 Turma

    public Turma Turma { get; set; }

    //Chave Estrangeira Matricula N : 1 Turma

    public int TurmaId { get; set; }



}
