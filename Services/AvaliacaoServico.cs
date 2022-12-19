using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class AvaliacaoServico
{

    private readonly AvaliacaoRepositorio _avaliacaoRepositorio;
  

    public AvaliacaoServico(
        [FromServices] AvaliacaoRepositorio repositorio
       
      )
    {

        _avaliacaoRepositorio = repositorio;
       
    }


    public AvaliacaoResposta CriarAvaliacao(AvaliacaoCriarAtualizarRequisicao novaAvaliacao)
    {

        var avaliacao = novaAvaliacao.Adapt<Avaliacao>();
        avaliacao = _avaliacaoRepositorio.CriarAvaliacao(avaliacao);
        var avaliacaoResposta = avaliacao.Adapt<AvaliacaoResposta>();
        return avaliacaoResposta;

    }

    public List<AvaliacaoResposta> ListarAvaliacoes()
    {
        var avaliacoes = _avaliacaoRepositorio.ListarAvaliacoes();

        //copiar do modelo pra resposta e retornar
        return avaliacoes.Adapt<List<AvaliacaoResposta>>();
    }

    private Avaliacao BuscarPeloId(int id, bool tracking = true)
    {
        var avaliacao = _avaliacaoRepositorio.BuscarAvaliacaoPeloId(id, tracking);

        if (avaliacao is null)
        {
            throw new Exception("Avaliacao não encontrada");
        }

        return avaliacao;
    }

    public AvaliacaoResposta BuscarAvaliacaoPeloId(int id)
    {
        var avaliacao = BuscarPeloId(id, false);

        //Copiar do modelo pra resposta e retornar
        return avaliacao.Adapt<AvaliacaoResposta>();
    }

    public void RemoverAvaliacao(int id)
    {
        var avaliacao = BuscarPeloId(id);
        _avaliacaoRepositorio.RemoverAvaliacao(avaliacao);
    }



    public AvaliacaoResposta AtualizarAvaliacao(int id, AvaliacaoCriarAtualizarRequisicao avaliacaoEditada)
    {
        var avaliacao = BuscarPeloId(id);
        avaliacaoEditada.Adapt(avaliacao);
        _avaliacaoRepositorio.AtualizarAvaliacao();
        return avaliacao.Adapt<AvaliacaoResposta>();

    }
}
