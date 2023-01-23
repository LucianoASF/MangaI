using MangaI.Dtos;
using Microsoft.AspNetCore.Mvc;
using MangaI.Services;
using Microsoft.AspNetCore.Authorization;

namespace MangaI.Controllers;

[ApiController]
[Route("disciplinas")]
public class DisciplinaController : ControllerBase
{

    private readonly DisciplinaServico _disciplinaServico;
    public DisciplinaController([FromServices] DisciplinaServico servico)
    {
        _disciplinaServico = servico;
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpPost]
    public ActionResult<DisciplinaResposta> PostDisciplina([FromBody] DisciplinaCriarAtualizarRequisicao novaDisciplina)
    {

        //Enviar para o serviço
        var disciplinaResposta = _disciplinaServico.CriarDisciplina(novaDisciplina);

        return CreatedAtAction(nameof(GetDisciplina),
            new { id = disciplinaResposta.Id },
           disciplinaResposta);

    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpGet]
    public ActionResult<List<DisciplinaResposta>> GetDisciplina()
    {
        //Pedir e retornar a lista que vem do servico
        return Ok(_disciplinaServico.ListarDisciplinas());
    }


    [Authorize]
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


    [Authorize(Roles = "Administrador")]
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


    [Authorize(Roles = "Administrador,Servidor")]
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


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpPut("{disciplinaId:int}/matrizes/{matrizId:int}")]
    public ActionResult<DisciplinaResposta> AtribuirOuDesatribuir([FromRoute] int disciplinaId, [FromRoute] int matrizId)
    {
        try
        {
            return Ok(_disciplinaServico.AtribuirOuDesatribuir(disciplinaId, matrizId));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
