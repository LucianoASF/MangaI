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

    public void PostDisciplina([FromBody] DisciplinaCriarAtualizarRequisicao novaDisciplina)
    {
        _disciplinaServico.CriarDisciplina(novaDisciplina);
    }
}
