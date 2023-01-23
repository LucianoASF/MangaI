using Microsoft.AspNetCore.Mvc;
using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Authorization;

namespace MangaI.Controllers;

[ApiController]
[Route("endereco")]
public class EnderecoController : ControllerBase
{
    private readonly EnderecoServico _enderecoServico;

    public EnderecoController([FromServices] EnderecoServico servico)
    {
        _enderecoServico = servico;
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpPost]
    public ActionResult<EnderecoResposta> PostEndereco([FromBody] EnderecoCriarAtualizarRequisicao novoEndereco)
    {
        var resposta = _enderecoServico.CriarEndereco(novoEndereco);
        return CreatedAtAction(nameof(GetEndereco), new { Id = resposta.Id }, resposta);
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpGet]
    public ActionResult<List<EnderecoResposta>> GetEnderecos()
    {
        return Ok(_enderecoServico.ListarEnderecos());
    }


    [Authorize]
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


    [Authorize(Roles = "Administrador,Servidor")]
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


    [Authorize(Roles = "Administrador,Servidor")]
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
