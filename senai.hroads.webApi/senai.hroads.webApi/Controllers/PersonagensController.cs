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
    // ex: http://localhost:5000/api/Personagens
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "2, 1")]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_personagemRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            try
            {
                if (idPersonagem <= 0)
                {
                    return NotFound(
                    new
                    {
                        mensagem = "Personagem não encontrado!",
                        errorStatus = true
                    }
                    );
                }
                return Ok(_personagemRepository.BuscarPorId(idPersonagem));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            try
            {
                _personagemRepository.Cadastrar(novoPersonagem);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Personagem personagemAtualizado)
        {
            try
            {
                _personagemRepository.Atualizar(personagemAtualizado);

                return StatusCode(204);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            try
            {
                if (idPersonagem <= 0)
                {
                    return NotFound(
                    new
                    {
                        mensagem = "Personagem não encontrado não encontrado!",
                        errorStatus = true
                    }
                    );
                }
                _personagemRepository.Deletar(idPersonagem);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
