using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Authorization;
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


    [Authorize(Roles = "Administrador,Professor")]
    [HttpPost]
    public ActionResult<AvaliacaoResposta> PostAvaliacao([FromBody] AvaliacaoCriarAtualizarRequisicao novaAvaliacao)
    {
        try
        {
            var resposta = _avaliacaoServico.CriarAvaliacao(novaAvaliacao);
            return CreatedAtAction(nameof(GetAvaliacao), new { Id = resposta.Id }, resposta);

        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor,Professor")]
    [HttpGet]
    public ActionResult<List<AvaliacaoResposta>> GetAvaliacoes()
    {
        return Ok(_avaliacaoServico.ListarAvaliacoes());
    }


    [Authorize]
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


    [Authorize(Roles = "Administrador,Servidor,Professor,Aluno")]
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


    [Authorize(Roles = "Administrador,Servidor,Professor")]
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
