using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaI.Repositorios;

public class DisciplinaRepositorio
{


    private ContextoBD _contexto;

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

    public Disciplina BuscarDisciplinaPeloId(int id, bool tracking)
    {
        //Buscar pelo id no contexto
        return tracking ? _contexto.Disciplinas.FirstOrDefault(disciplina => disciplina.Id == id)
        : _contexto.Disciplinas.AsNoTracking().FirstOrDefault(disciplina => disciplina.Id == id);
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
