using MangaI.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Data;

public class ContextoBD : DbContext
{
    public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
    {

    }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Disciplina> Disciplinas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Frequencia> Frequencias { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }
    public DbSet<Matriz> Matrizes { get; set; }
    public DbSet<NotaAluno> NotaAlunos { get; set; }
    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<Telefone> Telefones { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<Conteudo> Conteudos { get; set; }


}
