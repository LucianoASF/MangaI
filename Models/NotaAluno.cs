using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class NotaAluno
{

    [Column(TypeName = "decimal(13,2)")]
    public decimal NotaObtida { get; set; }

    //Propriedade de Navegação

    public Matricula Matricula { get; set; }

    //Chaves Estrangeiras

    public int AvaliacaoId { get; set; }

    public int UsuarioId { get; set; }
}
