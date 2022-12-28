using MangaI.Models;
using MangaI.Dtos;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class PerfilServico
{
    //Campo que é injetado no construtor
    private readonly PerfilRepositorio _perfilRepositorio;

    //Construtor com injecao de dependencia
    public PerfilServico([FromServices] PerfilRepositorio repositorio)
    {
        _perfilRepositorio = repositorio;
    }

    public PerfilResposta CriarPerfil
      (PerfilCriarAtualizarRequisicao novoPerfil)
    {
        //Copiar os dados da Requisicao para o Modelo
        var perfil = novoPerfil.Adapt<Perfil>();


        //Enviar o perfil para o Repositorio salvar no BD
        perfil = _perfilRepositorio.CriarPerfil(perfil);


        //Copiar do Modelo para a Resposta
        var perfilResposta = perfil.Adapt<PerfilResposta>();

        //retornar a resposta
        return perfilResposta;

    }

    public List<PerfilResposta> ListarPerfis()
    {
        //Pedir a lista de perfis do repositorio
        var perfis = _perfilRepositorio.ListarPerfis();

        //Copiar da lista de Modelo para Lista de Resposta
        var perfilRespostas = perfis.Adapt<List<PerfilResposta>>();

        //Retornar a lista de respostas
        return perfilRespostas;
    }

    public PerfilResposta BuscarPerfilPeloId(int id)
    {
        //Pedir o perfil do Repositorio
        var perfil = BuscarPeloId(id, false);

        //Copiar do Modelo (Perfil) para Resposta (PerfilResposta)
        return perfil.Adapt<PerfilResposta>();

    }

    public void RemoverPerfil(int id)
    {
        //Busar o perfil (modelo) pelo id
        var perfil = BuscarPeloId(id);

        //Mandar o repositorio remover o modelo
        _perfilRepositorio.RemoverPerfil(perfil);
    }

    public PerfilResposta AtualizarPerfil
      (int id, PerfilCriarAtualizarRequisicao perfilEditado)
    {
        //Buscar o modelo no repositorio
        var perfil = BuscarPeloId(id);

        //Copiar da Requisição para o Modelo
        perfilEditado.Adapt(perfil);

        //Mandar o repositorio salvar
        _perfilRepositorio.AtualizarPerfil();

        //Copiar do Modelo para Resposta
        return perfil.Adapt<PerfilResposta>();
    }

    private Perfil BuscarPeloId(int id, bool tracking = true)
    {
        var perfil = _perfilRepositorio.BuscarPerfilPeloId(id, tracking);

        if (perfil is null)
        {
            throw new Exception("Perfil não encontrado!");
        }

        return perfil;
    }
}
