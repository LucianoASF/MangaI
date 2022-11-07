using MangaI.Dtos;
using Microsoft.AspNetCore.Mvc;
using MangaI.Services;

namespace MangaI.Controllers;

[ApiController]
[Route("disciplinas")]
public class DisciplinaController : ControllerBase
{

    //Injetado no construtor
    private DisciplinaServico _disciplinaServico;

    //Construtor com Injecao de Dependencia
    public DisciplinaController([FromServices] DisciplinaServico servico)
    {
        _disciplinaServico = servico;
    }

    [HttpPost]
    public ActionResult<DisciplinaResposta> PostDisciplina
      ([FromBody] DisciplinaCriarAtualizarRequisicao novaDisciplina)
    {

        //Enviar para o serviço
        var disciplinaResposta = _disciplinaServico.CriarDisciplina(novaDisciplina);

        //retornando a resposta
        // return disicplinaResposta;
        // return StatusCode(201, disciplinaResposta);
        return CreatedAtAction(nameof(GetDisciplina),
            new { id = disciplinaResposta.Id },
           disciplinaResposta);

    }

    [HttpGet]
    public ActionResult<List<DisciplinaResposta>> GetDisciplina()
    {
        //Pedir e retornar a lista que vem do servico
        return Ok(_disciplinaServico.ListarDisciplinas());
    }

    [HttpGet("{id:int}")]
    public ActionResult<DisciplinaResposta> GetDisciplina([FromRoute] int id)
    {

        try
        {
            //Buscando e retornando a disciplina a partir do servico
            return Ok(_disciplinaServico.BuscarDisciplinaPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteDisciplina([FromRoute] int id)
    {

        try
        {
            //Mando o servico remover a disciplina
            _disciplinaServico.RemoverDisciplina(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpPut("{id:int}")]
    public ActionResult<DisciplinaResposta> PutDisciplina
      ([FromRoute] int id, [FromBody] DisciplinaCriarAtualizarRequisicao disciplinaEditado)
    {

        try
        {
            return Ok(_disciplinaServico.AtualizarDisciplina(id, disciplinaEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }
}
