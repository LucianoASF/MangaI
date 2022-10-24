using MangaI.Dtos;
using Microsoft.AspNetCore.Mvc;
using MangaI.Services;

namespace MangaI.Controllers;

[ApiController]
[Route("disciplinas")]
public class DisciplinaController : ControllerBase
{
    //Injetado no construtor
    private DisciplinaServico _disciplinaServico;

    //Construtor com Injecao de Dependencia
    public DisciplinaController([FromServices] DisciplinaServico servico)
    {
        _disciplinaServico = servico;
    }
    [HttpPost]

    public DisciplinaResposta PostDisciplina([FromBody] DisciplinaCriarAtualizarRequisicao novaDisciplina)
    {
        var disciplinaResposta = _disciplinaServico.CriarDisciplina(novaDisciplina);

        return disciplinaResposta;
    }
    [HttpGet]

    public List<DisciplinaResposta> GetDisciplinas()
    {
        var disciplinas = _disciplinaServico.ListarDisciplinas();

        return disciplinas;
    }
    [HttpGet("{id:int}")]
    public DisciplinaResposta GetDisciplina([FromRoute] int id)
    {
        var disciplina = _disciplinaServico.BuscarDisciplinaPeloId(id);
        return disciplina;
    }
    [HttpPut("{id:int}")]
    public DisciplinaResposta PutDisciplina([FromRoute] int id, [FromBody] DisciplinaCriarAtualizarRequisicao disciplinaEditada)
    {
        var disciplinaResposta = _disciplinaServico.AtualizarDisciplina(id, disciplinaEditada);
        return disciplinaResposta;
    }
    [HttpDelete("{id:int}")]

    public void DeleteDisciplina(int id)
    {
        _disciplinaServico.RemoverDisciplina(id);
    }
}
