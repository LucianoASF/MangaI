using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class FrequenciaServico
{
     private readonly FrequenciaRepositorio _frequenciaRepositorio;
   
    public FrequenciaServico(
        [FromServices] FrequenciaRepositorio repositorio
      )
    {
        _frequenciaRepositorio = repositorio;
    }

    public FrequenciaResposta CriarFrequencia(FrequenciaCriarAtualizarRequisicao novaFrequencia)
    {

        var frequencia = novaFrequencia.Adapt<Frequencia>();
        frequencia = _frequenciaRepositorio.CriarFrequencia(frequencia);
        var frequenciaResposta = frequencia.Adapt<FrequenciaResposta>();
        return frequenciaResposta;

    }

    public List<FrequenciaResposta> ListarFrequencias()
    {
        var frequencias = _frequenciaRepositorio.ListarFrequencias();
        
        return frequencias.Adapt<List<FrequenciaResposta>>();
    }

    private Frequencia BuscarPeloId(int id, bool tracking = true)
    {
        var frequencia = _frequenciaRepositorio.BuscarFrequenciaPeloId(id, tracking);

        if (frequencia is null)
        {
            throw new Exception("Frequencia não encontrada");
        }

        return frequencia;
    }

    public FrequenciaResposta BuscarFrequenciaPeloId(int id)
    {
        var frequencia = BuscarPeloId(id, false);

        //Copiar do modelo pra resposta e retornar
        return frequencia.Adapt<FrequenciaResposta>();
    }

    public void RemoverFrequencia(int id)
    {
        var frequencia = BuscarPeloId(id);

        _frequenciaRepositorio.RemoverFrequencia(frequencia);
    }



    public FrequenciaResposta AtualizarFrequencia(int id, FrequenciaCriarAtualizarRequisicao frequenciaEditada)
    {
        var frequencia = BuscarPeloId(id);
        frequenciaEditada.Adapt(frequencia);
        _frequenciaRepositorio.AtualizarFrequencia();
        return frequencia.Adapt<FrequenciaResposta>();

    }



}
