using Microsoft.AspNetCore.Mvc;
using MangaI.Dtos;
using MangaI.Services;

namespace MangaI.Controllers;

[ApiController]
[Route("endereco")]
public class EnderecoController : ControllerBase
{
    private EnderecoServico _enderecoServico;

    public EnderecoController([FromServices] EnderecoServico servico)
    {
        _enderecoServico = servico;
    }
    [HttpPost]
    public ActionResult<EnderecoResposta> PostEndereco([FromBody] EnderecoCriarAtualizarRequisicao novoEndereco)
    {
        var resposta = _enderecoServico.CriarEndereco(novoEndereco);
        return CreatedAtAction(nameof(GetEndereco), new { Id = resposta.Id }, resposta);
    }
    [HttpGet]
    public ActionResult<List<EnderecoResposta>> GetEnderecos()
    {
        return Ok(_enderecoServico.ListarEnderecos());
    }
    [HttpGet("{id:int}")]
    public ActionResult<EnderecoResposta> GetEndereco([FromRoute] int id)
    {
        try
        {
            return Ok(_enderecoServico.BuscarEnderecoPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public ActionResult DeleteEndereco([FromRoute] int id)
    {
        try
        {
            _enderecoServico.RemoverEndereco(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpPut("{id:int}")]
    public ActionResult<EnderecoResposta> PutEndereco([FromBody] EnderecoCriarAtualizarRequisicao enderecoEditado, [FromRoute] int id)
    {
        try
        {
            return Ok(_enderecoServico.AtualizarEndereco(enderecoEditado, id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

}
