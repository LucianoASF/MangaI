
using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Authorization;
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


    [Authorize(Roles = "Administrador,Servidor,Professor")]
    [HttpPost]
    public ActionResult<ConteudoResposta> PostConteudo([FromBody] ConteudoCriarAtualizarRequisicao novoConteudo)
    {
        try
        {
            var resposta = _conteudoServico.CriarConteudo(novoConteudo);
            return CreatedAtAction(nameof(GetConteudo), new { Id = resposta.Id }, resposta);

        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor,Professor")]
    [HttpGet]
    public ActionResult<List<ConteudoResposta>> GetConteudos()
    {
        return Ok(_conteudoServico.ListarConteudos());
    }


    [Authorize]
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


    [Authorize(Roles = "Administrador,Servidor,Professor")]
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


    [Authorize(Roles = "Administrador,Servidor,Professor")]
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
