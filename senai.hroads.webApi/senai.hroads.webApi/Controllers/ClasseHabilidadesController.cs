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
    [Authorize]
    public class ClasseHabilidadesController : ControllerBase
    {
        private IClasseHabilidadeRepository ClsshblddRepository { get; set; }
        public ClasseHabilidadesController()
        {
            ClsshblddRepository = new ClasseHabilidadeRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ClsshblddRepository.ListarTodos());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(ClsshblddRepository.BuscarPorID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            ClsshblddRepository.Cadastrar(novaClasseHabilidade);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, ClasseHabilidade chAtualizada)
        {
            ClsshblddRepository.AtualizarURL(id, chAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            ClsshblddRepository.Deletar(id);

            return StatusCode(204);
        }
        
        [Authorize(Roles = "1")]
        [HttpGet("classes")]
        public IActionResult ListarComClasses()
        {
            return Ok(ClsshblddRepository.ListarComClasseHabilidade());
        }
    }
}
