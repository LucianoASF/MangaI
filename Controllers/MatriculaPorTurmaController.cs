using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;

[ApiController]
[Route("matriculas-por-turma")]
public class MatriculaPorTurmaController : ControllerBase
{
    private readonly MatriculaPorTurmaServico _servico;
    public MatriculaPorTurmaController([FromServices] MatriculaPorTurmaServico m)
    {
        _servico = m;
    }


    [Authorize(Roles = "Administrador,Servidor,Aluno")]
    [HttpPost]
    public ActionResult<MatriculaPorTurmaResposta> PostMatriculaPorTurma([FromBody] MatriculaPorTurmaCriarAtualizarRequisicao novaMatricula)
    {
        var resposta = _servico.CriarMatriculaPorTurma(novaMatricula);
        return CreatedAtAction(nameof(GetMatriculaPorTurma), new { Id = resposta.Id }, resposta);

    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpGet]
    public ActionResult<List<MatriculaPorTurmaResposta>> GetMatriculasPorTurmas()
    {
        return Ok(_servico.ListarMatriculasPorTurma());
    }


    [Authorize]
    [HttpGet("{id:int}")]
    public ActionResult<MatriculaPorTurmaResposta> GetMatriculaPorTurma([FromRoute] int id)
    {
        try
        {
            return Ok(_servico.BuscarTurmaPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpDelete("{id:int}")]
    public ActionResult DeleteMatriculaPorTurma([FromRoute] int id)
    {
        try
        {
            _servico.RemoverMatriculaPorTurma(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor,Aluno")]
    [HttpPut("{id:int}")]
    public ActionResult<MatriculaPorTurmaResposta> PutMatriculaPorTurma([FromBody] MatriculaPorTurmaCriarAtualizarRequisicao novaMatricula, int id)
    {
        try
        {
            return Ok(_servico.AtualizarMatriculaPorTurma(novaMatricula, id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);

        }
    }



}
