using MangaI.Dtos;
using MangaI.Excecoes;
using MangaI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;

public class NotaAlunoController : ControllerBase
{
    private readonly NotaAlunoServico _notaAlunoServico;

    public NotaAlunoController([FromServices] NotaAlunoServico servico)
    {
        _notaAlunoServico = servico;
    }

    [HttpPost]
    public ActionResult<NotaAlunoResposta> PostNotaAluno(NotaAlunoCriarAtualizarRequisicao novaNotaAluno)
    {
        try
        {
            var notaAlunoResposta = _notaAlunoServico.CriarNotaAluno(novaNotaAluno);
            return CreatedAtAction(nameof(GetNotaAluno), new { Id = notaAlunoResposta.Id }, notaAlunoResposta);

        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<NotaAlunoResposta>> GetNotaAlunos()
    {
        return Ok(_notaAlunoServico.ListarNotaAlunos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<NotaAlunoResposta> GetNotaAluno([FromRoute] int id)
    {
        try
        {
            return Ok(_notaAlunoServico.BuscarNotaAlunoPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteNotaAluno([FromRoute] int id)
    {
        try
        {
            _notaAlunoServico.RemoverNotaAluno(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<NotaAlunoResposta>
      PutNotaAluno([FromRoute] int id, [FromBody] NotaAlunoCriarAtualizarRequisicao notaAlunoEditada)
    {
        try
        {
            return Ok(_notaAlunoServico.AtualizarNotaAluno(id, notaAlunoEditada));
        }
        catch (EmailExistenteException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


}
