using MangaI.Data;
using MangaI.Dtos;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class ConteudoRepositorio
{

    private readonly ContextoBD _contexto;

    public ConteudoRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public List<Conteudo> BuscarConteudosDaTurma(int turmaId)
    {
        return _contexto.Conteudos
          .AsNoTracking()
          .Where(a => a.TurmaId == turmaId)
          .ToList();
    }

    public Conteudo CriarConteudo(Conteudo conteudo)
    {
        _contexto.Conteudos.Add(conteudo);
        _contexto.SaveChanges();

        return conteudo;
    }

    public List<Conteudo> ListarConteudos()
    {
        return _contexto.Conteudos
          .Include(conteudo => conteudo.Turma)
          .AsNoTracking().ToList();
    }

    public Conteudo BuscarConteudoPeloId(int id, bool tracking = true)
    {
        return
        tracking
        ? _contexto.Conteudos
        .Include(conteudo => conteudo.Turma)
        .FirstOrDefault(a => a.Id == id)

        : _contexto.Conteudos

        .AsNoTracking()

        .Include(conteudo => conteudo.Turma)
        .FirstOrDefault(a => a.Id == id);
    }

    public void RemoverConteudo(Conteudo conteudo)
    {
        _contexto.Remove(conteudo);
        _contexto.SaveChanges();
    }



    public void AtualizarConteudo()
    {
        _contexto.SaveChanges();
    }
}