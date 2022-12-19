using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;


[ApiController]
[Route("telefones")]
public class TelefoneController : ControllerBase
{
   private readonly TelefoneServico _telefoneServico;

  public TelefoneController([FromServices] TelefoneServico servico)
  {
    _telefoneServico = servico;
  }

  [HttpPost]
  public ActionResult<TelefoneResposta>
    PostTelefone([FromBody]TelefoneCriarAtualizarRequisicao novoTelefone)
  {
    try
    {
      return StatusCode(201, _telefoneServico.CriarTelefone(novoTelefone));
    }
    catch (BadHttpRequestException e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<TelefoneResposta>> GetTelefones()
  {
    return Ok(_telefoneServico.ListarTelefones());
  }

  [HttpGet("{id:int}")]
  public ActionResult<TelefoneResposta> GetTelefone([FromRoute] int id)
  {
    try
    {
      return Ok(_telefoneServico.BuscarTelefonePeloId(id));
    }
    catch (Exception e)
    {
      return NotFound(e.Message);
    }
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteTelefone([FromRoute] int id)
  {
    try
    {
      _telefoneServico.RemoverTelefone(id);
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
    public ActionResult<TelefoneResposta> PutTelefone([FromBody] TelefoneCriarAtualizarRequisicao telefoneEditado, [FromRoute] int id)
    {
        try
        {
            return Ok(_telefoneServico.AtualizarTelefone(id, telefoneEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
