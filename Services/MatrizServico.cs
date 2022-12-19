using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class MatrizServico
{
    private readonly MatrizRepositorio _matrizRepositorio;
    // private readonly CursoRepositorio _cursoRepositorio;

    public MatrizServico(
        [FromServices] MatrizRepositorio repositorio
        // [FromServices] CursoRepositorio cRepositorio
      )
    {

        _matrizRepositorio = repositorio;
        // _cursoRepositorio = cRepositorio;
    }

    public MatrizResposta CriarMatriz(MatrizCriarAtualizarRequisicao novaMatriz)
    {

        var matriz = novaMatriz.Adapt<Matriz>();
        matriz = _matrizRepositorio.CriarMatriz(matriz);
        var matrizResposta = matriz.Adapt<MatrizResposta>();
        return matrizResposta;

    }

    public List<MatrizResposta> ListarMatrizes()
    {
        var matrizes = _matrizRepositorio.ListarMatrizes();

        //copiar do modelo pra resposta e retornar
        return matrizes.Adapt<List<MatrizResposta>>();
    }

    private Matriz BuscarPeloId(int id, bool tracking = true)
    {
        var matriz = _matrizRepositorio.BuscarMatrizPeloId(id, tracking);

        if (matriz is null)
        {
            throw new Exception("Matriz não encontrada");
        }

        return matriz;
    }

    public MatrizResposta BuscarMatrizPeloId(int id)
    {
        var matriz = BuscarPeloId(id, false);

        //Copiar do modelo pra resposta e retornar
        return matriz.Adapt<MatrizResposta>();
    }

    public void RemoverMatriz(int id)
    {
        var matriz = BuscarPeloId(id);

        _matrizRepositorio.RemoverMatriz(matriz);
    }



    public MatrizResposta AtualizarMatriz(int id, MatrizCriarAtualizarRequisicao matrizEditada)
    {
        var matriz = BuscarPeloId(id);
        matrizEditada.Adapt(matriz);
        _matrizRepositorio.AtualizarMatriz();
        return matriz.Adapt<MatrizResposta>();

    }



}
