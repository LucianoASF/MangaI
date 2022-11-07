using Mangal.Dtos;
using Mangal.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mangal.Controllers;

public class PerfilController : ControllerBase
{

    //Injetado no construtor
    private PerfilServico _perfilServico;

    //Construtor com Injecao de Dependencia
    public PerfilController([FromServices] PerfilServico servico)
    {
        _perfilServico = servico;
    }

    [HttpPost]
    public ActionResult<PerfilResposta> PostPerfil
      ([FromBody] PerfilCriarAtualizarRequisicao novoPerfil)
    {

        //Enviar para o serviço
        var perfilResposta = _perfilServico.CriarPerfil(novoPerfil);

        //retornando a resposta
        // return perfilResposta;
        // return StatusCode(201, perfilResposta);
        return CreatedAtAction(nameof(GetPerfil),
            new { id = perfilResposta.Id },
            perfilResposta);

    }

    [HttpGet]
    public ActionResult<List<PerfilResposta>> GetPerfil()
    {
        //Pedir e retornar a lista que vem do servico
        return Ok(_perfilServico.ListarPerfis());
    }

    [HttpGet("{id:int}")]
    public ActionResult<PerfilResposta> GetPerfil([FromRoute] int id)
    {

        try
        {
            //Buscando e retornando o Perfil a partir do servico
            return Ok(_perfilServico.BuscarPerfilPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletePerfil([FromRoute] int id)
    {

        try
        {
            //Mando o servico remover o Perfil
            _perfilServico.RemoverPerfil(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpPut("{id:int}")]
    public ActionResult<PerfilResposta> PutPerfil
      ([FromRoute] int id, [FromBody] PerfilCriarAtualizarRequisicao perfilEditado)
    {

        try
        {
            return Ok(_perfilServico.AtualizarPerfil(id, perfilEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }
}
