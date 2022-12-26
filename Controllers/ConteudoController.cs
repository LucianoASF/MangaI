
using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;



[ApiController]
[Route("conteudos")]
public class ConteudoController : ControllerBase
{
  private readonly ConteudoServico _conteudoServico;

  public ConteudoController([FromServices] ConteudoServico servico)
  {
    _conteudoServico = servico;
  }


  

  [HttpPost]
  public ActionResult<ConteudoResposta>
    PostConteudo([FromBody] ConteudoCriarAtualizarRequisicao novoConteudo)
  {
    try
    {
      return StatusCode(201, _conteudoServico.CriarConteudo(novoConteudo));
    }
    catch (BadHttpRequestException e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<ConteudoResposta>> GetConteudos()
  {
    return Ok(_conteudoServico.ListarConteudos());
  }

  [HttpGet("{id:int}")]
  public ActionResult<ConteudoResposta> GetConteudo([FromRoute] int id)
  {
    try
    {
      return Ok(_conteudoServico.BuscarConteudoPeloId(id));
    }
    catch (Exception e)
    {
      return NotFound(e.Message);
    }
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteConteudo([FromRoute] int id)
  {
    try
    {
      _conteudoServico.RemoverConteudo(id);
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
    public ActionResult<ConteudoResposta> PutConteudo([FromBody] ConteudoCriarAtualizarRequisicao conteudoEditado, [FromRoute] int id)
    {
        try
        {
            return Ok(_conteudoServico.AtualizarConteudo(id, conteudoEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
