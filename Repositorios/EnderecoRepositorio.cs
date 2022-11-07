using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Repositorios;

public class EnderecoRepositorio
{
    private ContextoBD _contextoBD;
    public EnderecoRepositorio([FromServices] ContextoBD contexto)
    {
        _contextoBD = contexto;
    }
    public Endereco CriarEndereco(Endereco novoEndereco)
    {
        _contextoBD.Add(novoEndereco);
        _contextoBD.SaveChanges();
        return novoEndereco;
    }
    public List<Endereco> ListarEnderecos()
    {
        return _contextoBD.Enderecos.ToList();
    }
    public Endereco BuscarEnderecoPeloId(int id)
    {
        return _contextoBD.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
    }
    public void RemoverEndereco(Endereco endereco)
    {
        _contextoBD.Remove(endereco);
        _contextoBD.SaveChanges();
    }
    public void AtualizarEndereco()
    {
        _contextoBD.SaveChanges();
    }
}
