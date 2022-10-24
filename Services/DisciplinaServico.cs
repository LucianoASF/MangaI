using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class DisciplinaServico
{
    //Campo que é injetado no construtor
    private DisciplinaRepositorio _disciplinaRepositorio;

    //Construtor com injecao de dependencia
    public DisciplinaServico([FromServices] DisciplinaRepositorio repositorio)
    {
        _disciplinaRepositorio = repositorio;
    }

    public DisciplinaResposta CriarDisciplina
       (DisciplinaCriarAtualizarRequisicao novaDisciplina)
    {
        //Copiar os dados da Requisicao para o Modelo
        var disciplina = new Disciplina();
        ConverterRequisicaoParaModelo(novaDisciplina, disciplina);

        //Regra de negócio
        var agora = DateTime.Now;
        disciplina.DataCriacao = agora;
        disciplina.DataAtualizacao = agora;

        //Enviar o procedimento para o Repositorio salvar no BD
        disciplina = _disciplinaRepositorio.CriarDisciplina(disciplina);


        //Copiar do Modelo para a Resposta
        var disciplinaResposta = ConverterModeloParaResposta(disciplina);

        //retornar a resposta
        return disciplinaResposta;

    }

    
    public void RemoverDisciplina(int id)
    {
        //Busar o procedimento (modelo) pelo id
        var disciplina = _disciplinaRepositorio.BuscarDisciplinaPeloId(id);

        if (disciplina is null)
        {
            return; //no futuro vai ser uma exceção
        }

        //Mandar o repositorio remover o modelo
        _disciplinaRepositorio.RemoverDisciplina(disciplina);
    }


}
