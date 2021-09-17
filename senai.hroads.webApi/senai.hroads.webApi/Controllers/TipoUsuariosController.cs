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
    // ex: http://localhost:5000/api/TipoUsuarios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(int idTipoUsuario)
        {
            try
            {
                if (idTipoUsuario <= 0)
                {
                    return NotFound(
                    new
                    {
                        mensagem = "Tipo de Usuário não encontrado!",
                        errorStatus = true
                    }
                );
                }
                return Ok(_tipoUsuarioRepository.BuscarPorId(idTipoUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipo)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(TipoUsuario tipoAtualizado)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(tipoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idTipoUsuario}")]
        public IActionResult Deletar(int idTipoUsuario)
        {
            try
            {
                if (idTipoUsuario <= 0)
                {
                    return NotFound(
                    new
                    {
                        mensagem = "Tipo de Usuário não encontrado não encontrado!",
                        errorStatus = true
                    }
                );
                }

                _tipoUsuarioRepository.Deletar(idTipoUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
