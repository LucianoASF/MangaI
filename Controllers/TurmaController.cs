using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;

[ApiController]
[Route("turmas")]
public class TurmaController : ControllerBase
{
    private readonly TurmaServico _turmaServico;
    public TurmaController([FromServices] TurmaServico servico)
    {
        _turmaServico = servico;
    }
    [HttpPost]
    public ActionResult<TurmaResposta> PostTurma([FromBody] TurmaCriarAtualizarRequisicao turma)
    {
        var resposta = _turmaServico.CriarTurma(turma);
        return CreatedAtAction(nameof(GetTurma), new { id = resposta.Id }, resposta);
    }
    [HttpGet]
    public ActionResult<List<TurmaResposta>> GetTurmas()
    {
        return Ok(_turmaServico.ListarTurmas());
    }
    [HttpGet("{id:int}")]
    public ActionResult<TurmaResposta> GetTurma([FromRoute] int id)
    {
        try
        {
            return Ok(_turmaServico.BuscarTurmaPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public ActionResult DeleteTurma([FromRoute] int id)
    {
        try
        {
            _turmaServico.RemoverTurma(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }
    [HttpPut("{id:int}")]
    public ActionResult<TurmaResposta> PutTurma([FromRoute] int id, [FromBody] TurmaCriarAtualizarRequisicao novaTurma)
    {
        try
        {
            return Ok(_turmaServico.AtualizarTurma(id, novaTurma));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpGet("{turmaId:int}/avaliacoes")]

    public ActionResult<List<TurmaResposta>> GetAvaliacoesPorTurma([FromRoute] int turmaId)
    {
        try
        {
            return Ok(_turmaServico.BuscarAvaliacaoesDaTurma(turmaId));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }



}
