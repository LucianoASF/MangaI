using System.ComponentModel.DataAnnotations;

namespace MangaI.Models;

public class Turma
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int Ano { get; set; }

    //propriedade de Navegação Turma N : 1 Disciplina 

    public Disciplina Disciplina { get; set; }

    //chave estrangeira Turma N : 1 Disciplina 

    public int DisciplinaId { get; set; }

    //propriedade de Navegação Turma 1 : N Avaliação

    public List<Avaliacao> Avaliacoes { get; set; }

    //Propriedade de Navegação Conteudo N : 1 Turma

    public List<Conteudo> Conteudos { get; set; }

    //propriedade de Navegação Turma 1 : N MatriculaPorTurma

    public List<MatriculaPorTurma> MatriculaPorTurmas { get; set; }



}
