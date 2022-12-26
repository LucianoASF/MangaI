using MangaI.Dtos;
using MangaI.Services;
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
    [HttpPost]
    public MatriculaPorTurmaResposta PostMatriculaPorTurma([FromBody] MatriculaPorTurmaCriarAtualizarRequisicao novaMatricula)
    {
        return _servico.CriarMatriculaPorTurma(novaMatricula);
    }
    [HttpGet]
    public ActionResult<List<MatriculaPorTurmaResposta>> GetMatriculasPorTurmas()
    {
        return Ok(_servico.ListarMatriculasPorTurma());
    }
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
