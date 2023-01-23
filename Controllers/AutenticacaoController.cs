using MangaI.Dtos;
using MangaI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;

[ApiController]
[Route("[controller]")]
public class AutenticacaoController : ControllerBase
{
    private readonly AutenticacaoServico _autenticacaoServico;

    public AutenticacaoController([FromServices] AutenticacaoServico servico)
    {
        _autenticacaoServico = servico;
    }


    [HttpPost]
    public ActionResult<string> Login([FromBody] UsuarioLoginRequisicao usuarioLogin)
    {
        try
        {
            //Manda para o servico gerar o token
            var tokenJWT = _autenticacaoServico.Login(usuarioLogin);

            return Ok(tokenJWT);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
