using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Curso
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(35)")]
    public string NomeCurso { get; set; }



    //Propriedade de navegação Curso 1 : N Matriz
    public List<Matriz> Matrizes { get; set; }





}