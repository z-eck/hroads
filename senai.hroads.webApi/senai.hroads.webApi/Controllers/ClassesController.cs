using Microsoft.AspNetCore.Authorization;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClassesController : ControllerBase
    {
        private IClasseRepository ClssRepository { get; set; }
        public ClassesController()
        {
            ClssRepository = new ClasseRepository();
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ClssRepository.ListarTodos());
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(ClssRepository.BuscarPorID(id));
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Classe novaClasse)
        {
            ClssRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{idClasse}")]
        public IActionResult AtualizarURL(int idClasse, Classe classeAtualizada)
        {
            try
            {
                ClssRepository.AtualizarURL(idClasse, classeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            ClssRepository.Deletar(id);

            return StatusCode(204);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("personagem")]
        public IActionResult ListarComPersonagem()
        {
            return Ok(ClssRepository.ListarComPersonagem());
        }
    }
}
