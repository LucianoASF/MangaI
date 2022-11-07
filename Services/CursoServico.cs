using MangaI.Models;
using Mangal.Dtos;
using Mangal.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Mangal.Services;

public class CursoServico
{
    //Campo que é injetado no construtor
    private CursoRepositorio _cursoRepositorio;

    //Construtor com injecao de dependencia
    public CursoServico([FromServices] CursoRepositorio repositorio)
    {
        _cursoRepositorio = repositorio;
    }

    public CursoResposta CriarCurso
       (CursoCriarAtualizarRequisicao novoCurso)
    {
        //Copiar os dados da Requisicao para o Modelo
        var curso = novoCurso.Adapt<Curso>();

        //Enviar o curso para o Repositorio salvar no BD
        curso = _cursoRepositorio.CriarCurso(curso);

        //Copiar do Modelo para a Resposta
        var cursoResposta = curso.Adapt<CursoResposta>();

        //retornar a resposta
        return cursoResposta;

    }

    public List<CursoResposta> ListarCursos()
    {
        //Pedir a lista de curso do repositorio
        var cursos = _cursoRepositorio.ListarCursos();


        //Copiar da lista de Modelo para Lista de Resposta
        var cursoRespostas = cursos.Adapt<List<CursoResposta>>();


        //Retornar a lista de respostas
        return cursoRespostas;
    }

    public CursoResposta BuscarCursoPeloId(int id)
    {
        //Pedir o curso do Repositorio
        var curso = BuscarPeloId(id, false);

        //Copiar do Modelo (Curso) para Resposta (CursoResposta)
        return curso.Adapt<CursoResposta>();

    }

    public void RemoverCurso(int id)
    {
        //Busar o curso (modelo) pelo id
        var curso = BuscarPeloId(id);

        //Mandar o repositorio remover o modelo
        _cursoRepositorio.RemoverCurso(curso);
    }

    public CursoResposta AtualizarCurso
      (int id, CursoCriarAtualizarRequisicao cursoEditado)
    {
        //Buscar o modelo no repositorio
        var curso = BuscarPeloId(id);

        //Copiar da Requisição para o Modelo
        cursoEditado.Adapt(curso);

        //Mandar o repositorio salvar
        _cursoRepositorio.AtualizarCurso();

        //Copiar do Modelo para Resposta
        return curso.Adapt<CursoResposta>();
    }

    private Curso BuscarPeloId(int id, bool tracking = true)
    {
        var curso = _cursoRepositorio.BuscarCursoPeloId(id, tracking);

        if (curso is null)
        {
            throw new Exception("Curso não encontrado!");
        }

        return curso;
    }
}
