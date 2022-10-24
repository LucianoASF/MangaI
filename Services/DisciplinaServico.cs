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
