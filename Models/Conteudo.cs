using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Conteudo
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Tema { get; set; }

    [Required]
    public DateTime Dia { get; set; }


    //Propriedade de Navegação Conteudo 1 : N Frequencia

    public List<Frequencia> Frequencias { get; set; }

}
