using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Frequencia
{
    [Required]
    public int Id { get; set; }

    [Required]
    public bool Presente { get; set; }

    [Required]
    public DateTime Dia { get; set; }

    [Required]
    [Column(TypeName = "text")]

    public string Conteudo { get; set; }

    //Propriedade de Navegação Frequencia N : 1 Matricula

    public Matricula Matricula { get; set; }

    //Chave Estrangeira Frequencia N : 1 Matricula

    public int MatriculaId { get; set; }
}
