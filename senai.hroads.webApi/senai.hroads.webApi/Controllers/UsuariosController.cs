using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Usuarios

    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
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
            try
            {
                 _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Atualizar (Usuario usuarioAtualizado)
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
        public IActionResult Deletar (int idUsuario)
        {
            try
            {
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
