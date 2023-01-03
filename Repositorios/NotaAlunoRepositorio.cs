using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class NotaAlunoRepositorio
{
    private readonly ContextoBD _contexto;

    public NotaAlunoRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public List<NotaAluno> BuscarNotaAluno(int MatriculaPorTurmaId, int avaliacaoId)
    {
        return _contexto.NotaAlunos
          .AsNoTracking()
          .Where(a => a.MatriculaPorTurmaId == MatriculaPorTurmaId && a.AvaliacaoId == avaliacaoId)
          .ToList();
    }

    public NotaAluno CriarNotaAluno(NotaAluno notaAluno)
    {
        _contexto.NotaAlunos.Add(notaAluno);
        _contexto.SaveChanges();

        return notaAluno;
    }

    public List<NotaAluno> ListarNotaAlunos()
    {
        return _contexto.NotaAlunos
          .Include(notaAluno => notaAluno.MatriculaPorTurmaId)
          .Include(notaAluno => notaAluno.Avaliacao)
          .AsNoTracking().ToList();
    }

    public NotaAluno BuscarNotaAlunoPeloId(int id, bool tracking = true)
    {
        return
        tracking
        ? _contexto.NotaAlunos
        .Include(notaAluno => notaAluno.MatriculaPorTurmaId)
        .Include(notaAluno => notaAluno.Avaliacao)
        .FirstOrDefault(a => a.Id == id)
        : _contexto.NotaAlunos
        .AsNoTracking()
        .Include(notaAluno => notaAluno.MatriculaPorTurmaId)
        .Include(notaAluno => notaAluno.Avaliacao)

        .FirstOrDefault(a => a.Id == id);
    }

    public void RemoverNotaAluno(NotaAluno notaAluno)
    {
        _contexto.Remove(notaAluno);
        _contexto.SaveChanges();
    }



    public void AtualizarNotaAluno()
    {
        _contexto.SaveChanges();

    }

}
