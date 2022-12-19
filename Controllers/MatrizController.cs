
using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;


[ApiController]
[Route("matrizes")]
public class MatrizController : ControllerBase
{
  private readonly MatrizServico _matrizServico;

  public MatrizController([FromServices] MatrizServico servico)
  {
    _matrizServico = servico;
  }

  [HttpPost]
  public ActionResult<MatrizResposta>
    PostMatriz([FromBody] MatrizCriarAtualizarRequisicao novaMatriz)
  {
    try
    {
      return StatusCode(201, _matrizServico.CriarMatriz(novaMatriz));
    }
    catch (BadHttpRequestException e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<MatrizResposta>> GetMatrizes()
  {
    return Ok(_matrizServico.ListarMatrizes());
  }

  [HttpGet("{id:int}")]
  public ActionResult<MatrizResposta> GetMatriz([FromRoute] int id)
  {
    try
    {
      return Ok(_matrizServico.BuscarMatrizPeloId(id));
    }
    catch (Exception e)
    {
      return NotFound(e.Message);
    }
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteMatriz([FromRoute] int id)
  {
    try
    {
      _matrizServico.RemoverMatriz(id);
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
    public ActionResult<MatrizResposta> PutMatriz([FromBody] MatrizCriarAtualizarRequisicao matrizEditada, [FromRoute] int id)
    {
        try
        {
            return Ok(_matrizServico.AtualizarMatriz(id, matrizEditada));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
