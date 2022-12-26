using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class AvaliacaoRepositorio
{
    
    private ContextoBD _contexto;

    public AvaliacaoRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public List<Avaliacao> BuscarAvaliacaoesDaTurma(int turmaId)
    {
        return _contexto.Avaliacoes
          .AsNoTracking()
          .Where(a => a.TurmaId == turmaId)
          .ToList();
    }

    public Avaliacao CriarAvaliacao(Avaliacao avaliacao)
    {
        _contexto.Avaliacoes.Add(avaliacao);
        _contexto.SaveChanges();

        return avaliacao;
    }

    public List<Avaliacao> ListarAvaliacoes()
    {
        return _contexto.Avaliacoes
          .Include(avaliacao => avaliacao.Turma)
          .AsNoTracking().ToList();
    }

    public Avaliacao BuscarAvaliacaoPeloId(int id, bool tracking = true)
    {
        return
        tracking
        ? _contexto.Avaliacoes
        .Include(avaliacao => avaliacao.Turma)
        .FirstOrDefault(a => a.Id == id)

        : _contexto.Avaliacoes

        .AsNoTracking()
       
        .Include(avaliacao => avaliacao.Turma)
        .FirstOrDefault(a => a.Id == id);
    }

    public void RemoverAvaliacao(Avaliacao avaliacao)
    {
        _contexto.Remove(avaliacao);
        _contexto.SaveChanges();
    }



    public void AtualizarAvaliacao()
    {
        _contexto.SaveChanges();
    }


}
