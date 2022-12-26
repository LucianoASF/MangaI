using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class MatriculaServico
{
    private readonly MatriculaRepositorio _matricula;

    public MatriculaServico([FromServices] MatriculaRepositorio matricula)
    {
        _matricula = matricula;
    }

    public MatriculaResposta CriarMatricula(MatriculaCriarAtualizarRequisicao matricula)
    {
        var matriculaAdaptada = matricula.Adapt<Matricula>();
        var resposta = _matricula.CriarMatricula(matriculaAdaptada);
        return resposta.Adapt<MatriculaResposta>();
    }
    public List<MatriculaResposta> ListarMatriculas()
    {
        return _matricula.ListarMatriculas().Adapt<List<MatriculaResposta>>();
    }
    private Matricula BuscarPeloId(int id, bool tracking = true)
    {
        var matricula = _matricula.BuscarMatriculaPeloId(id, tracking);
        if (matricula is null)
        {
            throw new Exception("Matricula não encontrada");
        }
        return matricula;
    }
    public MatriculaResposta BuscarMatriculaPeloId(int id)
    {
        var matricula = BuscarPeloId(id, false);
        return matricula.Adapt<MatriculaResposta>();
    }
    public void RemoverMatricula(int id)
    {
        var matricula = BuscarPeloId(id);
        _matricula.RemoverMatricula(matricula);
    }
    public MatriculaResposta AtualizarMatricula(int id, MatriculaCriarAtualizarRequisicao novaMatricula)
    {
        var matricula = BuscarPeloId(id);
        novaMatricula.Adapt(matricula);
        _matricula.AtualizarMatricula();
        return matricula.Adapt<MatriculaResposta>();
    }
}
