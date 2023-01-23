using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;

[ApiController]
[Route("matriculas")]
public class MatriculaController : ControllerBase
{
    private readonly MatriculaServico _matricula;

    public MatriculaController([FromServices] MatriculaServico servico)
    {
        _matricula = servico;
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpPost]
    public ActionResult<MatriculaResposta> PostMatricula([FromBody] MatriculaCriarAtualizarRequisicao matricula)
    {
        var resposta = _matricula.CriarMatricula(matricula);
        return CreatedAtAction(nameof(GetMatricula), new { Id = resposta.Id }, resposta);

    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpGet]
    public ActionResult<List<MatriculaResposta>> GetMatriculas()
    {
        return Ok(_matricula.ListarMatriculas());
    }


    [Authorize(Roles = "Administrador,Servidor,Aluno")]
    [HttpGet("{id:int}")]
    public ActionResult<MatriculaResposta> GetMatricula([FromRoute] int id)
    {
        try
        {
            return Ok(_matricula.BuscarMatriculaPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpDelete("{id:int}")]
    public ActionResult DeleteMatricula([FromRoute] int id)
    {
        try
        {
            _matricula.RemoverMatricula(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpPut("{id:int}")]
    public ActionResult<MatriculaResposta> PutMatricula([FromRoute] int id, [FromBody] MatriculaCriarAtualizarRequisicao novaMatricula)
    {
        try
        {
            return Ok(_matricula.AtualizarMatricula(id, novaMatricula));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


}
