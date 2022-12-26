using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class ConteudoServico
{
     private readonly ConteudoRepositorio _conteudoRepositorio;
  

    public ConteudoServico(
        [FromServices] ConteudoRepositorio repositorio
       
      )
    {

        _conteudoRepositorio = repositorio;
       
    }


    public ConteudoResposta CriarConteudo(ConteudoCriarAtualizarRequisicao novoConteudo)
    {

        var conteudo = novoConteudo.Adapt<Conteudo>();
        conteudo = _conteudoRepositorio.CriarConteudo(conteudo);
        var conteudoResposta = conteudo.Adapt<ConteudoResposta>();
        return conteudoResposta;

    }

    public List<ConteudoResposta> ListarConteudos()
    {
        var avaliacoes = _conteudoRepositorio.ListarConteudos();

        //copiar do modelo pra resposta e retornar
        return avaliacoes.Adapt<List<ConteudoResposta>>();
    }

    private Conteudo BuscarPeloId(int id, bool tracking = true)
    {
        var conteudo = _conteudoRepositorio.BuscarConteudoPeloId(id, tracking);

        if (conteudo is null)
        {
            throw new Exception("Conteudo não encontrada");
        }

        return conteudo;
    }

    public ConteudoResposta BuscarConteudoPeloId(int id)
    {
        var conteudo = BuscarPeloId(id, false);

        //Copiar do modelo pra resposta e retornar
        return conteudo.Adapt<ConteudoResposta>();
    }

    public void RemoverConteudo(int id)
    {
        var conteudo = BuscarPeloId(id);
        _conteudoRepositorio.RemoverConteudo(conteudo);
    }



    public ConteudoResposta AtualizarConteudo(int id, ConteudoCriarAtualizarRequisicao conteudoEditada)
    {
        var conteudo = BuscarPeloId(id);
        conteudoEditada.Adapt(conteudo);
        _conteudoRepositorio.AtualizarConteudo();
        return conteudo.Adapt<ConteudoResposta>();

    }
}
