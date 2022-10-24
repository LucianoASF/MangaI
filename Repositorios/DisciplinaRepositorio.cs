using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Repositorios;

public class DisciplinaRepositorio
{

    //Campo que vai ser injetado no construtor
    private ContextoBD _contexto;

    //Construtor que injeta a dependencia
    public DisciplinaRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Disciplina CriarDisciplina(Disciplina disciplina)
    {
        //Manda o contexto salvar no BD
        _contexto.Disciplinas.Add(disciplina);
        _contexto.SaveChanges();

        //Vai estar preenchido com a chave primária
        return disciplina;
    }

    public List<Disciplina> ListarDisciplinas()
    {
        return _contexto.Disciplinas.ToList();
    }

    public Disciplina BuscarDisciplinaPeloId(int id)
    {
        //Buscar pelo id no contexto
        return _contexto.Disciplinas.FirstOrDefault(disciplina => disciplina.Id == id);
    }

    public void RemoverDisciplina(Disciplina disciplina)
    {
        //Mandar o contexto remover
        _contexto.Remove(disciplina);
        _contexto.SaveChanges();

    }

     public void AtualizarDisciplina()
  {
    _contexto.SaveChanges();
  }


}
