using MangaI.Dtos;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class TelefoneServico
{
    private readonly TelefoneRepositorio _telefoneRepositorio;
    // private readonly UsuarioRepositorio _usuarioRepositorio;

    public TelefoneServico(
        [FromServices]TelefoneRepositorio repositorio
        // [FromServices] UsuarioRepositorio uRepositorio
      )
    {

        _telefoneRepositorio = repositorio;
        // _usuarioRepositorio = uRepositorio;
    }

    public TelefoneResposta CriarTelefone(TelefoneCriarAtualizarRequisicao novoTelefone)
    {

        var telefone = novoTelefone.Adapt<Telefone>();
        telefone = _telefoneRepositorio.CriarTelefone(telefone);
        var telefoneResposta = telefone.Adapt<TelefoneResposta>();
        return telefoneResposta;

    }

    public List<TelefoneResposta> ListarTelefones()
    {
        var telefones = _telefoneRepositorio.ListarTelefones();

        //copiar do modelo pra resposta e retornar
        return telefones.Adapt<List<TelefoneResposta>>();
    }

    private Telefone BuscarPeloId(int id, bool tracking = true)
    {
        var telefone = _telefoneRepositorio.BuscarTelefonePeloId(id, tracking);

        if (telefone is null)
        {
            throw new Exception("Telefone não encontrado");
        }

        return telefone;
    }

    public TelefoneResposta BuscarTelefonePeloId(int id)
    {
        var telefone = BuscarPeloId(id, false);

        //Copiar do modelo pra resposta e retornar
        return telefone.Adapt<TelefoneResposta>();
    }

    public void RemoverTelefone(int id)
    {
        var telefone = BuscarPeloId(id);

        _telefoneRepositorio.RemoverTelefone(telefone);
    }


    public TelefoneResposta AtualizarTelefone(int id, TelefoneCriarAtualizarRequisicao telefoneEditado)
        {
            var telefone = BuscarPeloId(id);
            telefoneEditado.Adapt(telefone);
            _telefoneRepositorio.AtualizarTelefone();
            return telefone.Adapt<TelefoneResposta>();

        }

}