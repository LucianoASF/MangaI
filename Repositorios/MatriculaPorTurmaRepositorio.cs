using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class MatriculaPorTurmaRepositorio
{
    private readonly ContextoBD _contextoBD;

    public MatriculaPorTurmaRepositorio([FromServices] ContextoBD contexto)
    {
        _contextoBD = contexto;
    }
    public MatriculaPorTurma CriarMatriculaPorTurma(MatriculaPorTurma matricula)
    {
        _contextoBD.Add(matricula);
        _contextoBD.SaveChanges();
        return matricula;
    }
    public List<MatriculaPorTurma> ListarMatriculasPorTurma()
    {
        return _contextoBD.MatriculaPorTurmas.Include(m => m.Matricula).Include(m => m.Turma).ToList();
    }
    public MatriculaPorTurma BuscarMatriculaPeloId(int id, bool tracking = true)
    {
        return tracking ? _contextoBD.MatriculaPorTurmas.Include(m => m.Matricula).Include(m => m.Turma).FirstOrDefault(m => m.Id == id)
        : _contextoBD.MatriculaPorTurmas.AsNoTracking().Include(m => m.Matricula).Include(m => m.Turma).FirstOrDefault(m => m.Id == id);
    }
    public void RemoverMatriculaPorTurma(MatriculaPorTurma matricula)
    {
        _contextoBD.Remove(matricula);
        _contextoBD.SaveChanges();
    }
    public void AtualizarMatriculaPorTurma()
    {
        _contextoBD.SaveChanges();
    }
}
