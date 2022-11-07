using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;

namespace MangaI.Services;

public class ConteudoServico
{
    private ConteudoRepositorio _conteudoRepositorio;

    public ConteudoServico(ConteudoRepositorio repositorio)
    {
        _conteudoRepositorio = repositorio;
    }
    private Conteudo BuscarPeloId(int id, bool tracking = true)
    {
        var resposta = _conteudoRepositorio.BuscarConteudoPeloId(id, tracking);
        if (resposta is null)
        {
            throw new Exception("Conteúdo não encontrado!");
        }
        return resposta;
    }
    public ConteudoResposta CriarConteudo(ConteudoCriarAtualizarRequisicao novoConteudo)
    {
        var conteudo = novoConteudo.Adapt<Conteudo>();
        var resposta = _conteudoRepositorio.CriarConteudo(conteudo);
        var respostaAdaptada = resposta.Adapt<ConteudoResposta>();
        return respostaAdaptada;

    }
    public List<ConteudoResposta> ListarConteudos()
    {
        var resposta = _conteudoRepositorio.ListarConteudos();
        var respostaAdaptada = resposta.Adapt<List<ConteudoResposta>>();
        return respostaAdaptada;
    }
    public ConteudoResposta BuscarConteudoPeloId(int id)
    {
        var resposta = BuscarPeloId(id, false);
        var respostaAdaptada = resposta.Adapt<ConteudoResposta>();
        return respostaAdaptada;
    }
    public void RemoverConteudo(int id)
    {
        var conteudo = BuscarPeloId(id);
        _conteudoRepositorio.RemoverConteudo(conteudo);


    }
    public ConteudoResposta AtualizarConteudo(int id, ConteudoCriarAtualizarRequisicao conteudoEditado)
    {
        var conteudo = BuscarPeloId(id);
        conteudoEditado.Adapt(conteudo);
        _conteudoRepositorio.AtualizarConteudo();
        return conteudo.Adapt<ConteudoResposta>();


    }
}
