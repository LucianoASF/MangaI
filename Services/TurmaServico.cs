using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class TurmaServico
{
    private readonly TurmaRepositorio _turmaRepositorio;

    public TurmaServico([FromServices] TurmaRepositorio repositorio)
    {
        _turmaRepositorio = repositorio;
    }
    public TurmaResposta CriarTurma(TurmaCriarAtualizarRequisicao turma)
    {

        var novaTurma = _turmaRepositorio.CriarTurma(turma.Adapt<Turma>());
        return novaTurma.Adapt<TurmaResposta>();
    }
    public List<TurmaResposta> ListarTurmas()
    {
        var resposta = _turmaRepositorio.ListarTurmas();
        return resposta.Adapt<List<TurmaResposta>>();
    }
    private Turma BuscarPeloId(int id, bool tracking = true)
    {
        var resposta = _turmaRepositorio.BuscarTurmaPeloId(id, tracking);
        if (resposta is null)
        {
            throw new Exception("Turma não encontrada");
        }
        return resposta;
    }
    public TurmaResposta BuscarTurmaPeloId(int id)
    {
        var resposta = BuscarPeloId(id, false);
        return resposta.Adapt<TurmaResposta>();
    }
    public void RemoverTurma(int id)
    {
        var turma = BuscarPeloId(id);
        _turmaRepositorio.RemoverTurma(turma);
    }
    public TurmaResposta AtualizarTurma(int id, TurmaCriarAtualizarRequisicao novaTurma)
    {
        var turma = BuscarPeloId(id);
        novaTurma.Adapt(turma);
        _turmaRepositorio.AtualizarTurma();
        return turma.Adapt<TurmaResposta>();
    }

}
