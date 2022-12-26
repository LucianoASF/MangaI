using MangaI.Dtos;
using MangaI.Excecoes;
using MangaI.Models;
using MangaI.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MangaI.Services;

public class UsuarioServico
{

    private readonly UsuarioRepositorio _usuarioRepositorio;

    public UsuarioServico
      ([FromServices] UsuarioRepositorio repositorio)
    {
        _usuarioRepositorio = repositorio;

    }

    public UsuarioResposta CriarUsuario(UsuarioCriarRequisicao novoUsuario)
    {

        var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloEmail(novoUsuario.Email);
        if (usuarioExistente is not null)
        {
            throw new BadHttpRequestException("Já existe um usuário com esse email");
        }

        var usuario = novoUsuario.Adapt<Usuario>();

        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
        usuario = _usuarioRepositorio.CriarUsuario(usuario);

        var usuarioResposta = usuario.Adapt<UsuarioResposta>();

        return usuarioResposta;
    }

    public List<UsuarioResposta> ListarUsuarios()
    {
        return _usuarioRepositorio.ListarUsuarios().Adapt<List<UsuarioResposta>>();
    }

    public UsuarioResposta BuscarUsuarioPeloId(int id)
    {
        return BuscarPeloId(id).Adapt<UsuarioResposta>();
    }

    private Usuario BuscarPeloId(int id, bool tracking = true)
    {
        var usuario = _usuarioRepositorio.BuscarUsuarioPeloId(id, tracking);

        if (usuario is null)
        {
            throw new Exception("Usuário não encontrado");
        }

        return usuario;
    }

    public void RemoverUsuario(int id)
    {
        var usuario = BuscarPeloId(id);
        _usuarioRepositorio.RemoverUsuario(usuario);
    }

    public UsuarioResposta AtualizarUsuario(int id, UsuarioCriarRequisicao usuarioEditado)
    {

        var usuario = BuscarPeloId(id);

        if (usuario.Email != usuarioEditado.Email)
        {
            var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloEmail(usuarioEditado.Email);
            if (usuarioExistente is not null)
            {
                throw new EmailExistenteException();
            }
        }

        usuarioEditado.Adapt(usuario);
        _usuarioRepositorio.AtualizarUsuario();
        var usuarioResposta = usuario.Adapt<UsuarioResposta>();

        return usuarioResposta;

    }

}
