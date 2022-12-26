using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class NotaAluno
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "decimal(13,2)")]
    public decimal NotaObtida { get; set; }

    //Propriedade de Navegação NotaAluno N : 1 MatriculaPorTurma

    public MatriculaPorTurma MatriculaPorTurma { get; set; }

    //Chave Estrangeira NotaAluno N : 1 MatriculaPorTurma

    public int MatriculaPorTurmaId { get; set; }


    //Propriedade de Navegação NotaAluno N : 1 Avaliação

    public Avaliacao Avaliacao { get; set; }

    //chave estrangeira NotaAluno N : 1 Avaliação

    public int AvaliacaoId { get; set; }



}
