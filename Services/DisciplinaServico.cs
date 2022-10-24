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

        //Enviar a disciplina para o Repositorio salvar no BD
        disciplina = _disciplinaRepositorio.CriarDisciplina(disciplina);


        //Copiar do Modelo para a Resposta
        var disciplinaResposta = ConverterModeloParaResposta(disciplina);

        //retornar a resposta
        return disciplinaResposta;

    }

    public List<DisciplinaResposta> ListarDisciplina()
    {
        //Pedir a lista de Disciplina do repositorio
        var disciplinas = _disciplinaRepositorio.ListarDisciplinas();

        //Criar a lista de respostas
        List<DisciplinaResposta> disciplinaRespostas = new();

        //Copiar os dados do Modelo (Disciplina) para a Resposta (DisciplinaResposta)
        foreach (var disicplina in disciplinas)
        {
            //Copiar de Modelo para Resposta
            var disciplinaResposta = ConverterModeloParaResposta(disciplina);

            //Adicionar a reposta na lista
            disciplinaRespostas.Add(disciplinaResposta);
        }

        //Retornar a lista de respostas
        return disciplinaRespostas;
    }

    private DisciplinaResposta ConverterModeloParaResposta(Disciplina modelo)
    {
        var disciplinaResposta = new DisciplinaResposta();
        disciplinaResposta.Id = modelo.Id;
        disciplinaResposta.Nome = modelo.Nome;
        disciplinaResposta.CargaHoraria = modelo.CargaHoraria;

        return disciplinaResposta;
    }

    public  DisciplinaResposta BuscarDisciplinaPeloId(int id)
    {
        //Pedir a  disciplina do Repositorio
        var disciplina = _disciplinaRepositorio.BuscarDisciplinaPeloId(id);

        if (disciplina is null)
        {
            return null; //no futuro vai ser uma excecao
        }

        //Copiar do Modelo (Disciplina) para Resposta (DisciplinaResposta)
        return ConverterModeloParaResposta(disciplina);

    }

    public void RemoverDisciplina(int id)
    {
        //Busar a disciplina (modelo) pelo id
        var disciplina = _disciplinaRepositorio.BuscarDisciplinaPeloId(id);

        if (disciplina is null)
        {
            return; //no futuro vai ser uma exceção
        }

        //Mandar o repositorio remover o modelo
        _disciplinaRepositorio.RemoverDisciplina(disciplina);
    }
    
    
  public DisciplinaResposta AtualizarDisciplina
    (int id, DisciplinaCriarAtualizarRequisicao disciplinaEditado)
  {
    //Buscar o modelo no repositorio
    var disciplina = _disciplinaRepositorio.BuscarDisciplinaPeloId(id);

    if (disciplina is null)
    {
      return null; //no futuro vai ser uma exceção
    }

    //Copiar da Requisição para o Modelo
    ConverterRequisicaoParaModelo(disciplinaEditado, disciplina);

    //Mandar o repositorio salvar
    _disciplinaRepositorio.AtualizarDisciplina();

    //Copiar do Modelo para Resposta
    return ConverterModeloParaResposta(disciplina);
  }

  private void ConverterRequisicaoParaModelo
    (DisciplinaCriarAtualizarRequisicao requisicao, Disciplina modelo)
  {
    modelo.Nome = requisicao.Nome;
    modelo.CargaHoraria = requisicao.CargaHoraria;
  }

}



