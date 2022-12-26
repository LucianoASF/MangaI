using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class DisciplinaServico
{

    //Campo que é injetado no construtor
    private readonly DisciplinaRepositorio _disciplinaRepositorio;
    private readonly MatrizRepositorio _matrizRepositorio;

    //Construtor com injecao de dependencia
    public DisciplinaServico([FromServices] DisciplinaRepositorio repositorio, [FromServices] MatrizRepositorio matrizRepositorio)
    {
        _disciplinaRepositorio = repositorio;
        _matrizRepositorio = matrizRepositorio;
    }

    public DisciplinaResposta CriarDisciplina
      (DisciplinaCriarAtualizarRequisicao novaDisciplina)
    {
        //Copiar os dados da Requisicao para o Modelo
        var disciplina = novaDisciplina.Adapt<Disciplina>();


        //Enviar a disciplina para o Repositorio salvar no BD
        disciplina = _disciplinaRepositorio.CriarDisciplina(disciplina);


        //Copiar do Modelo para a Resposta
        var disciplinaResposta = disciplina.Adapt<DisciplinaResposta>();

        //retornar a resposta
        return disciplinaResposta;

    }

    public List<DisciplinaResposta> ListarDisciplinas()
    {
        //Pedir a lista de disciplinas do repositorio
        var disciplinas = _disciplinaRepositorio.ListarDisciplinas();

        //Copiar da lista de Modelo para Lista de Resposta
        var disciplinaRespostas = disciplinas.Adapt<List<DisciplinaResposta>>();

        //Retornar a lista de respostas
        return disciplinaRespostas;
    }

    public DisciplinaResposta BuscarDisciplinaPeloId(int id)
    {
        //Pedir a disciplina do Repositorio
        var disciplina = BuscarPeloId(id, false);

        //Copiar do Modelo (Disciplina) para Resposta (DisciplinaResposta)
        return disciplina.Adapt<DisciplinaResposta>();

    }

    public void RemoverDisciplina(int id)
    {
        //Busar o Disciplina (modelo) pelo id
        var disciplina = BuscarPeloId(id);

        //Mandar o repositorio remover o modelo
        _disciplinaRepositorio.RemoverDisciplina(disciplina);
    }

    public DisciplinaResposta AtualizarDisciplina
      (int id, DisciplinaCriarAtualizarRequisicao disciplinaEditado)
    {
        //Buscar o modelo no repositorio
        var disciplina = BuscarPeloId(id);

        //Copiar da Requisição para o Modelo
        disciplinaEditado.Adapt(disciplina);

        //Mandar o repositorio salvar
        _disciplinaRepositorio.AtualizarDisciplina();

        //Copiar do Modelo para Resposta
        return disciplina.Adapt<DisciplinaResposta>();
    }

    private Disciplina BuscarPeloId(int id, bool tracking = true)
    {
        var disciplina = _disciplinaRepositorio.BuscarDisciplinaPeloId(id, tracking);

        if (disciplina is null)
        {
            throw new Exception("Disciplina não encontrada!");
        }

        return disciplina;
    }
    public DisciplinaResposta AtribuirMatriz(int disciplinaId, int matrizId)
    {
        var disciplina = BuscarPeloId(disciplinaId);
        var matriz = _matrizRepositorio.BuscarMatrizPeloId(matrizId);
        if (disciplina.Matrizes.Exists(m => m.Id == matrizId))
        {
            throw new BadHttpRequestException("Essa Disciplina já esta adicionada nessa Matriz");
        }
        disciplina.Matrizes.Add(matriz);
        _disciplinaRepositorio.AtualizarDisciplina();
        return disciplina.Adapt<DisciplinaResposta>();

    }

}



