using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class NotaAlunoServico
{
     private readonly NotaAlunoRepositorio _notaAlunoRepositorio;
   
    public NotaAlunoServico(
        [FromServices] NotaAlunoRepositorio repositorio
      )
    {
        _notaAlunoRepositorio = repositorio;
    }

    public NotaAlunoResposta CriarNotaAluno(NotaAlunoCriarAtualizarRequisicao novaNotaAluno)
    {

        var notaAluno = novaNotaAluno.Adapt<NotaAluno>();
        notaAluno = _notaAlunoRepositorio.CriarNotaAluno(notaAluno);
        var notaAlunoResposta = notaAluno.Adapt<NotaAlunoResposta>();
        return notaAlunoResposta;

    }

    public List<NotaAlunoResposta> ListarNotaAlunos()
    {
        var notaAlunos = _notaAlunoRepositorio.ListarNotaAlunos();
        
        return notaAlunos.Adapt<List<NotaAlunoResposta>>();
    }

    private NotaAluno BuscarPeloId(int id, bool tracking = true)
    {
        var notaAluno = _notaAlunoRepositorio.BuscarNotaAlunoPeloId(id, tracking);

        if (notaAluno is null)
        {
            throw new Exception("Nota do aluno não encontrada");
        }

        return notaAluno;
    }

    public NotaAlunoResposta BuscarNotaAlunoPeloId(int id)
    {
        var notaAluno = BuscarPeloId(id, false);

        //Copiar do modelo pra resposta e retornar
        return notaAluno.Adapt<NotaAlunoResposta>();
    }

    public void RemoverNotaAluno(int id)
    {
        var notaAluno = BuscarPeloId(id);

        _notaAlunoRepositorio.RemoverNotaAluno(notaAluno);
    }



    public NotaAlunoResposta AtualizarNotaAluno(int id, NotaAlunoCriarAtualizarRequisicao notaAlunoEditada)
    {
        var notaAluno = BuscarPeloId(id);
        notaAlunoEditada.Adapt(notaAluno);
        _notaAlunoRepositorio.AtualizarNotaAluno();
        return notaAluno.Adapt<NotaAlunoResposta>();

    }


}
