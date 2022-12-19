using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Repositorios;

public class PerfilRepositorio
{
    private ContextoBD _contexto;
    public PerfilRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Perfil CriarPerfil(Perfil perfil)
    {
        //Manda o contexto salvar no BD
        _contexto.Perfis.Add(perfil);
        _contexto.SaveChanges();

        //Vai estar preenchido com a chave primária
        return perfil;
    }

    public List<Perfil> ListarPerfis()
    {
        return _contexto.Perfis.ToList();
    }

    public Perfil BuscarPerfilPeloId(int id, bool tracking)
    {
        //Buscar pelo id no contexto
        return _contexto.Perfis.FirstOrDefault(perfil => perfil.Id == id);
    }

    public void RemoverPerfil(Perfil perfil)
    {
        //Mandar o contexto remover
        _contexto.Remove(perfil);
        _contexto.SaveChanges();

    }

    public void AtualizarPerfil()
    {
        _contexto.SaveChanges();
    }
}
