using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Perfil
{
    [Required]
    public int Id {get; set;}

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string Nome {get; set;}

    
    //Propriedade de navegação
    public List<Usuario> Usuarios { get; set; }

}
