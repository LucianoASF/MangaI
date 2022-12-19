using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class TelefoneRepositorio
{
    private ContextoBD _contexto;

    public TelefoneRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public List<Telefone> BuscarTelefoneDoUsuario(int usuarioId)
    {
        return _contexto.Telefones
          .AsNoTracking()
          .Where(a => a.UsuarioId == usuarioId)
          .ToList();
    }

    public Telefone CriarTelefone(Telefone telefone)
    {
        _contexto.Telefones.Add(telefone);
        _contexto.SaveChanges();

        return telefone;
    }

    public List<Telefone> ListarTelefones()
    {
        return _contexto.Telefones
          //   .Include(telefone => telefone.Cliente)
          .Include(telefone => telefone.Usuario)
          .AsNoTracking().ToList();
    }

    public Telefone BuscarTelefonePeloId(int id, bool tracking = true)
    {
        return
          tracking
          ? _contexto.Telefones
        // .Include(telefone => telefone.Cliente) vai pegar o Inerjoin da tabela usuario
        .Include(telefone => telefone.Usuario)
        .FirstOrDefault(a => a.Id == id)

        : _contexto.Telefones

        .AsNoTracking()
   // .Include(telefone => telefone.Cliente)
        .Include(telefone => telefone.Usuario)
        .FirstOrDefault(a => a.Id == id);
    }

    public void RemoverTelefone(Telefone telefone)
    {
        _contexto.Remove(telefone);
        _contexto.SaveChanges();
    }

  public void AtualizarTelefone()
    {
        _contexto.SaveChanges();
       
    }

}