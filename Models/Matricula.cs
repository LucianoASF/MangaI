using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Matricula
{

    [Column(TypeName = "Decimal(13,2)")]


    public Decimal NotaFinal { get; set; }

    //Propriedade de Navegação

    public Usuario Usuario { get; set; }

    //Chave Estrangeira

    public int UsuarioId { get; set; }

    //Propriedade de Navegação
    public List<NotaAluno> NotasAlunos { get; set; }
}
