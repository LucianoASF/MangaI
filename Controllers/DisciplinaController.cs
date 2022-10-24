using MangaI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Controllers;

[ApiController]
[Route("disciplinas")]
public class DisciplinaController : ControllerBase
{
[HttpPost]

public void PostDisciplina([FromBody] DisciplinaCriarAtualizarRequisicao novaDisciplina)
{
 //
}
}
