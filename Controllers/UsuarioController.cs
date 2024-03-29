using MangaI.Dtos;
using MangaI.Excecoes;
using MangaI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;


[ApiController]
[Route("usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioServico _usuarioServico;

    public UsuarioController([FromServices] UsuarioServico servico)
    {
        _usuarioServico = servico;
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpPost]
    public ActionResult<UsuarioResposta> PostUsuario(UsuarioCriarRequisicao novoUsuario)
    {
        try
        {
            var usuarioResposta = _usuarioServico.CriarUsuario(novoUsuario);
            return CreatedAtAction(nameof(GetUsuario), new { Id = usuarioResposta.Id }, usuarioResposta);

        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize(Roles = "Administrador,Servidor,Professor")]
    [HttpGet]
    public ActionResult<List<UsuarioResposta>> GetUsuarios()
    {
        return Ok(_usuarioServico.ListarUsuarios());
    }


    [Authorize]
    [HttpGet("{id:int}")]
    public ActionResult<UsuarioResposta> GetUsuario([FromRoute] int id)
    {
        try
        {
            return Ok(_usuarioServico.BuscarUsuarioPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id:int}")]
    public ActionResult DeleteUsuario([FromRoute] int id)
    {
        try
        {
            _usuarioServico.RemoverUsuario(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor")]
    [HttpPut("{id:int}")]
    public ActionResult<UsuarioResposta> PutUsuario([FromRoute] int id, [FromBody] UsuarioCriarRequisicao usuarioEditado)
    {
        try
        {
            return Ok(_usuarioServico.AtualizarUsuario(id, usuarioEditado));
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
