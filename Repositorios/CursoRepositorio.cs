using MangaI.Data;
using MangaI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Repositorios;

public class CursoRepositorio
{
    //Campo que vai ser injetado no construtor
    private ContextoBD _contexto;

    //Construtor que injeta a dependencia
    public CursoRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Curso CriarCurso(Curso curso)
    {
        //Manda o contexto salvar no BD
        _contexto.Cursos.Add(curso);
        _contexto.SaveChanges();

        //Vai estar preenchido com a chave primária
        return curso;
    }

    public List<Curso> ListarCursos()
    {
        return _contexto.Cursos.ToList();
    }

    public Curso BuscarCursoPeloId(int id, bool tracking)
    {
        //Buscar pelo id no contexto
        return _contexto.Cursos.FirstOrDefault(curso => curso.Id == id);
    }

    public void RemoverCurso(Curso curso)
    {
        //Mandar o contexto remover
        _contexto.Remove(curso);
        _contexto.SaveChanges();

    }

    public void AtualizarCurso()
    {
        _contexto.SaveChanges();
    }


}
