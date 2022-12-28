
using Microsoft.AspNetCore.Mvc;
using MangaI.Dtos;
using MangaI.Services;

namespace MangaI.Controllers;

[ApiController]
[Route("cursos")]
public class CursoController : ControllerBase
{
    private readonly CursoServico _cursoServico;
    public CursoController([FromServices] CursoServico servico)
    {
        _cursoServico = servico;
    }

    [HttpPost]
    public ActionResult<CursoResposta> PostCurso
      ([FromBody] CursoCriarAtualizarRequisicao novoCurso)
    {

        //Enviar para o serviço
        var cursoResposta = _cursoServico.CriarCurso(novoCurso);


        return CreatedAtAction(nameof(GetCurso),
            new { id = cursoResposta.Id },
            cursoResposta);

    }

    [HttpGet]
    public ActionResult<List<CursoResposta>> GetCurso()
    {
        //Pedir e retornar a lista que vem do servico
        return Ok(_cursoServico.ListarCursos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<CursoResposta> GetCurso([FromRoute] int id)
    {

        try
        {
            //Buscando e retornando ocurso a partir do servico
            return Ok(_cursoServico.BuscarCursoPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteCurso([FromRoute] int id)
    {

        try
        {
            //Mando o servico remover o curso
            _cursoServico.RemoverCurso(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpPut("{id:int}")]
    public ActionResult<CursoResposta> PutCurso
      ([FromRoute] int id, [FromBody] CursoCriarAtualizarRequisicao cursoEditado)
    {

        try
        {
            return Ok(_cursoServico.AtualizarCurso(id, cursoEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

}


