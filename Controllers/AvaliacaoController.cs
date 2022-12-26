using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;



[ApiController]
[Route("avaliacoes")]
public class AvaliacaoController : ControllerBase
{
  private readonly AvaliacaoServico _avaliacaoServico;

  public AvaliacaoController([FromServices] AvaliacaoServico servico)
  {
    _avaliacaoServico = servico;
  }


  

  [HttpPost]
  public ActionResult<AvaliacaoResposta>
    PostAvaliacao([FromBody] AvaliacaoCriarAtualizarRequisicao novaAvaliacao)
  {
    try
    {
      return StatusCode(201, _avaliacaoServico.CriarAvaliacao(novaAvaliacao));
    }
    catch (BadHttpRequestException e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<AvaliacaoResposta>> GetAvaliacoes()
  {
    return Ok(_avaliacaoServico.ListarAvaliacoes());
  }

  [HttpGet("{id:int}")]
  public ActionResult<AvaliacaoResposta> GetAvaliacao([FromRoute] int id)
  {
    try
    {
      return Ok(_avaliacaoServico.BuscarAvaliacaoPeloId(id));
    }
    catch (Exception e)
    {
      return NotFound(e.Message);
    }
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteAvaliacao([FromRoute] int id)
  {
    try
    {
      _avaliacaoServico.RemoverAvaliacao(id);
      return NoContent();
    }
    catch (BadHttpRequestException e)
    {
      return BadRequest(e.Message);
    }
    catch (Exception e)
    {
      return NotFound(e.Message);
    }
  }

    [HttpPut("{id:int}")]
    public ActionResult<AvaliacaoResposta> PutAvaliacao([FromBody] AvaliacaoCriarAtualizarRequisicao avaliacaoEditada, [FromRoute] int id)
    {
        try
        {
            return Ok(_avaliacaoServico.AtualizarAvaliacao(id, avaliacaoEditada));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
