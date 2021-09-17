using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;

namespace senai.hroads.webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Usuarios

    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "1")]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            Usuario usuarioBuscado = new Usuario();
            try
            {
                if (usuarioBuscado.IdTipoUsuario <= 0)
                {
                    return NotFound(
                    new
                    {
                        mensagem = "Usuário não encontrado não encontrado!",
                        errorStatus = true
                    }
                    );
                }
                return Ok(_usuarioRepository.BuscarPorId(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            Usuario usuarioBuscado = new Usuario();

            try
            {
                if (novoUsuario.Email == usuarioBuscado.Email)
                {
                    return Conflict(
                    new
                    {
                        mensagem = "Email já cadastrado",
                        errorStatus = true
                    });
                }
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Usuario usuarioAtualizado)
        {

            try
            {
                _usuarioRepository.AtualizarUsuario(usuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            try
            {
                if (idUsuario <= 0)
                {
                    return NotFound(
                    new
                    {
                        mensagem = "Usuário não encontrado não encontrado!",
                        errorStatus = true
                    }
                    );
                }
                _usuarioRepository.Deletar(idUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
