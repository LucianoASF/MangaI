using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class MatriculaPorTurmaServico
{
    private readonly MatriculaPorTurmaRepositorio _repositorio;
    public MatriculaPorTurmaServico([FromServices] MatriculaPorTurmaRepositorio repo)
    {
        _repositorio = repo;
    }
    public MatriculaPorTurmaResposta CriarMatriculaPorTurma(MatriculaPorTurmaCriarAtualizarRequisicao matricula)
    {
        var resposta = _repositorio.CriarMatriculaPorTurma(matricula.Adapt<MatriculaPorTurma>());
        return resposta.Adapt<MatriculaPorTurmaResposta>();
    }
    public List<MatriculaPorTurmaResposta> ListarMatriculasPorTurma()
    {
        var resposta = _repositorio.ListarMatriculasPorTurma();
        return resposta.Adapt<List<MatriculaPorTurmaResposta>>();
    }
    public MatriculaPorTurmaResposta BuscarTurmaPeloId(int id)
    {
        return BuscarPeloId(id, false).Adapt<MatriculaPorTurmaResposta>();
    }
    private MatriculaPorTurma BuscarPeloId(int id, bool tracking = true)
    {

        var matricula = _repositorio.BuscarMatriculaPeloId(id, tracking);
        if (matricula is null)
        {
            throw new Exception("Matricula Por Turma não encontrada!");
        }
        return matricula;

    }
    public void RemoverMatriculaPorTurma(int id)
    {
        var matricula = BuscarPeloId(id);
        _repositorio.RemoverMatriculaPorTurma(matricula);
    }
    public MatriculaPorTurmaResposta AtualizarMatriculaPorTurma(MatriculaPorTurmaCriarAtualizarRequisicao matriculaAtualizada, int id)
    {
        var matricula = BuscarPeloId(id);
        matricula.Adapt(matriculaAtualizada);
        _repositorio.AtualizarMatriculaPorTurma();
        return matricula.Adapt<MatriculaPorTurmaResposta>();
    }

}
