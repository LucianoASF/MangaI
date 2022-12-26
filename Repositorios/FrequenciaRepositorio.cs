using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class FrequenciaRepositorio
{
    private ContextoBD _contexto;

    public FrequenciaRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public List<Frequencia> BuscarFrequencia(int conteudoId, int matriculaId)
    {
        return _contexto.Frequencias
          .AsNoTracking()
          .Where(a => a.ConteudoId == conteudoId && a.MatriculaId == matriculaId)
          .ToList();
    }

    public Frequencia CriarFrequencia(Frequencia frequencia)
    {
        _contexto.Frequencias.Add(frequencia);
        _contexto.SaveChanges();

        return frequencia;
    }

    public List<Frequencia> ListarFrequencias()
    {
        return _contexto.Frequencias

          .Include(frequencia => frequencia.Conteudo)
          .Include(frequencia => frequencia.Matricula)
          .AsNoTracking().ToList();
    }

    public Frequencia BuscarFrequenciaPeloId(int id, bool tracking = true)
    {
        return
        tracking
        ? _contexto.Frequencias
        .Include(frequencia => frequencia.Conteudo)
        .Include(frequencia => frequencia.Matricula)
        .FirstOrDefault(a => a.Id == id)
        : _contexto.Frequencias
        .AsNoTracking()
        .Include(frequencia => frequencia.Conteudo)
        .Include(frequencia => frequencia.Matricula)

        .FirstOrDefault(a => a.Id == id);
    }

    public void RemoverFrequencia(Frequencia frequencia)
    {
        _contexto.Remove(frequencia);
        _contexto.SaveChanges();
    }



    public void AtualizarFrequencia()
    {
        _contexto.SaveChanges();

    }

}
