using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;

[ApiController]
[Route("conteudo")]

public class ConteudoController : ControllerBase
{
    private ConteudoServico _conteudoServico;
    public ConteudoController(ConteudoServico servico)
    {
        _conteudoServico = servico;
    }

    [HttpPost]
    public ActionResult<ConteudoResposta> PostConteudo([FromBody] ConteudoCriarAtualizarRequisicao novoConteudo)
    {
        var conteudoResposta = _conteudoServico.CriarConteudo(novoConteudo);
        return CreatedAtAction(nameof(GetConteudo), new { id = conteudoResposta.Id }, conteudoResposta);
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
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }
    [HttpPut("{id:int}")]
    public ActionResult<ConteudoResposta> PutConteudo([FromRoute] int id, [FromBody] ConteudoCriarAtualizarRequisicao conteudoEditado)
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
