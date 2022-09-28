using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaI.Models;

public class Frequencia
{
    [Required]
    public int Id { get; set; }

    [Required]
    public bool Presente { get; set; }



    //Propriedade de Navegação Frequencia N : 1 Conteudo

    public Conteudo Conteudo { get; set; }

    //Chave Estrangeira Frequencia N : 1 Conteudo

    public int ConteudoId { get; set; }
}
