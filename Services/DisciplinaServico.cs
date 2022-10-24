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

    public DisciplinaResposta CriarProcedimento
       (DisciplinaCriarAtualizarRequisicao novaDisciplina)
    {
        //Copiar os dados da Requisicao para o Modelo
        var disciplina = new Disciplina();
        ConverterRequisicaoParaModelo(novoProcedimento, procedimento);

        //Regra de negócio
        var agora = DateTime.Now;
        procedimento.DataCriacao = agora;
        procedimento.DataAtualizacao = agora;

        //Enviar o procedimento para o Repositorio salvar no BD
        procedimento = _procedimentoRepositorio.CriarProcedimento(procedimento);


        //Copiar do Modelo para a Resposta
        var procedimentoResposta = ConverterModeloParaResposta(procedimento);

        //retornar a resposta
        return procedimentoResposta;

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
