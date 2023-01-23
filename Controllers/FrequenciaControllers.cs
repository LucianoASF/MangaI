using MangaI.Dtos;
using MangaI.Excecoes;
using MangaI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;


[ApiController]
[Route("frequencias")]

public class FrequenciaController : ControllerBase
{
    private readonly FrequenciaServico _frequenciaServico;

    public FrequenciaController([FromServices] FrequenciaServico servico)
    {
        _frequenciaServico = servico;
    }


    [Authorize(Roles = "Administrador,Servidor,Professor")]
    [HttpPost]
    public ActionResult<FrequenciaResposta> PostFrequencia(FrequenciaCriarAtualizarRequisicao novaFrequencia)
    {
        try
        {
            var frequenciaResposta = _frequenciaServico.CriarFrequencia(novaFrequencia);
            return CreatedAtAction(nameof(GetFrequencia), new { Id = frequenciaResposta.Id }, frequenciaResposta);

        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor,Professor")]
    [HttpGet]
    public ActionResult<List<FrequenciaResposta>> GetFrequencias()
    {
        return Ok(_frequenciaServico.ListarFrequencias());
    }


    [Authorize]
    [HttpGet("{id:int}")]
    public ActionResult<FrequenciaResposta> GetFrequencia([FromRoute] int id)
    {
        try
        {
            return Ok(_frequenciaServico.BuscarFrequenciaPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor,Professor")]
    [HttpDelete("{id:int}")]
    public ActionResult DeleteFrequencia([FromRoute] int id)
    {
        try
        {
            _frequenciaServico.RemoverFrequencia(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [Authorize(Roles = "Administrador,Servidor,Professor")]
    [HttpPut("{id:int}")]
    public ActionResult<FrequenciaResposta>
      PutFrequencia([FromRoute] int id, [FromBody] FrequenciaCriarAtualizarRequisicao frequenciaEditada)
    {
        try
        {
            return Ok(_frequenciaServico.AtualizarFrequencia(id, frequenciaEditada));
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
