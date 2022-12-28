using MangaI.Dtos;
using MangaI.Repositorios;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace MangaI.Services;

public class EnderecoServico
{
    private readonly EnderecoRepositorio _enderecoRepositorio;
    public EnderecoServico([FromServices] EnderecoRepositorio repositorio)
    {
        _enderecoRepositorio = repositorio;
    }
    private Endereco BuscarPeloId(int id, bool tracking = true)
    {
        var endereco = _enderecoRepositorio.BuscarEnderecoPeloId(id, tracking);
        if (endereco is null)
        {
            throw new Exception("Endereço não encontrado!");
        }
        return endereco;
    }
    public EnderecoResposta CriarEndereco(EnderecoCriarAtualizarRequisicao novoEndereco)
    {
        var endereco = novoEndereco.Adapt<Endereco>();
        _enderecoRepositorio.CriarEndereco(endereco);
        var enderecoResposta = endereco.Adapt<EnderecoResposta>();
        return enderecoResposta;
    }
    public List<EnderecoResposta> ListarEnderecos()
    {
        var enderecos = _enderecoRepositorio.ListarEnderecos();
        var enderecosResposta = enderecos.Adapt<List<EnderecoResposta>>();
        return enderecosResposta;
    }
    public EnderecoResposta BuscarEnderecoPeloId(int id)
    {
        var endereco = BuscarPeloId(id, false);
        var resposta = endereco.Adapt<EnderecoResposta>();
        return resposta;

    }
    public void RemoverEndereco(int id)
    {
        var endereco = BuscarPeloId(id);
        _enderecoRepositorio.RemoverEndereco(endereco);
    }
    public EnderecoResposta AtualizarEndereco(EnderecoCriarAtualizarRequisicao enderecoEditado, int id)
    {
        var endereco = BuscarPeloId(id);
        enderecoEditado.Adapt(endereco);
        _enderecoRepositorio.AtualizarEndereco();
        return endereco.Adapt<EnderecoResposta>();
    }
}
