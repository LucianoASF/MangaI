using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class TurmaRepositorio
{
    private readonly ContextoBD _contexto;
    public TurmaRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Turma CriarTurma(Turma turma)
    {
        _contexto.Add(turma);
        _contexto.SaveChanges();
        return turma;
    }
    public List<Turma> ListarTurmas()
    {
        return _contexto.Turmas.AsNoTracking().Include(t => t.Disciplina).ToList();
    }
    public Turma BuscarTurmaPeloId(int id, bool tracking = true)
    {
        return tracking ? _contexto.Turmas.Include(t => t.Disciplina).FirstOrDefault(t => t.Id == id)
        : _contexto.Turmas.AsNoTracking().Include(t => t.Disciplina).FirstOrDefault(t => t.Id == id);
    }
    public void RemoverTurma(Turma turma)
    {
        _contexto.Remove(turma);
        _contexto.SaveChanges();
    }
    public void AtualizarTurma()
    {
        _contexto.SaveChanges();
    }

}
