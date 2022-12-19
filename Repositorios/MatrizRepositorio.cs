using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class MatrizRepositorio
{

    private ContextoBD _contexto;

    public MatrizRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public List<Matriz> BuscarMatrizesDoCurso(int cursoId)
    {
        return _contexto.Matrizes
          .AsNoTracking()
          .Where(a => a.CursoId == cursoId)
          .ToList();
    }

    public Matriz CriarMatriz(Matriz matriz)
    {
        _contexto.Matrizes.Add(matriz);
        _contexto.SaveChanges();

        return matriz;
    }

    public List<Matriz> ListarMatrizes()
    {
        return _contexto.Matrizes
          //   .Include(matriz => matriz.Cliente)
          .Include(matriz => matriz.Curso)

          .AsNoTracking().ToList();
    }

    public Matriz BuscarMatrizPeloId(int id, bool tracking = true)
    {
        return
          tracking
          ? _contexto.Matrizes
        // .Include(matriz => matriz.Cliente) vai pegar o Inerjoin da tabela usuario
        .Include(matriz => matriz.Curso)
        .FirstOrDefault(a => a.Id == id)

        : _contexto.Matrizes

        .AsNoTracking()
        // .Include(matriz => matriz.Cliente)
        .Include(matriz => matriz.Curso)
        .FirstOrDefault(a => a.Id == id);
    }

    public void RemoverMatriz(Matriz matriz)
    {
        _contexto.Remove(matriz);
        _contexto.SaveChanges();
    }



    public void AtualizarMatriz()
    {
        _contexto.SaveChanges();
    
    }


}

