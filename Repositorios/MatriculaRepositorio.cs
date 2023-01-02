using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class MatriculaRepositorio
{
    private readonly ContextoBD _contexto;
    public MatriculaRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }
    public Matricula CriarMatricula(Matricula matricula)
    {
        _contexto.Add(matricula);
        _contexto.SaveChanges();
        return matricula;
    }
    public List<Matricula> ListarMatriculas()
    {
        return _contexto.Matriculas.AsNoTracking().Include(m => m.Usuario).Include(m => m.Matriz).ToList();
    }
    public Matricula BuscarMatriculaPeloId(int id, bool tracking = true)
    {
        return tracking ? _contexto.Matriculas.Include(m => m.Usuario).Include(m => m.Matriz).FirstOrDefault(m => m.Id == id) :
        _contexto.Matriculas.AsNoTracking().Include(m => m.Usuario).Include(m => m.Matriz).FirstOrDefault(m => m.Id == id);
    }
    public void RemoverMatricula(Matricula matricula)
    {
        _contexto.Remove(matricula);
        _contexto.SaveChanges();
    }
    public void AtualizarMatricula()
    {
        _contexto.SaveChanges();
    }
}
