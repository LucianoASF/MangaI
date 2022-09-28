using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Disciplina
{
    [Required]
    public int Id { get; set; }


    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Nome { get; set; }

    [Required]

    public int CargaHoraria { get; set; }

    //Propriedade de Navegação

    public List<Matricula> Matriculas { get; set; }

    //propriedade de Navegação M-n

    public List<Matriz> Matrizes { get; set; }


}
