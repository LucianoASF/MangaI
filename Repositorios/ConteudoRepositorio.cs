using MangaI.Data;
using MangaI.Dtos;
using MangaI.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class ConteudoRepositorio
{
    private ContextoBD _contextoBD;

    public ConteudoRepositorio(ContextoBD contexto)
    {
        _contextoBD = contexto;
    }
    public Conteudo CriarConteudo(Conteudo conteudo)
    {
        _contextoBD.Add(conteudo);
        _contextoBD.SaveChanges();
        return conteudo;
    }
    public List<Conteudo> ListarConteudos()
    {
        return _contextoBD.Conteudos.AsNoTracking().ToList();
    }
    public Conteudo BuscarConteudoPeloId(int id, bool tracking = true)
    {
        return tracking ? _contextoBD.Conteudos.FirstOrDefault(conteudo => conteudo.Id == id)
        : _contextoBD.Conteudos.AsNoTracking().FirstOrDefault(conteudo => conteudo.Id == id);
    }
    public void RemoverConteudo(Conteudo conteudo)
    {
        _contextoBD.Remove(conteudo);
        _contextoBD.SaveChanges();
    }
    public void AtualizarConteudo()
    {
        _contextoBD.SaveChanges();
    }
}
