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
    public class ClasseHabilidadesController : ControllerBase
    {
        private IClasseHabilidadeRepository ClsshblddRepository { get; set; }
        public ClasseHabilidadesController()
        {
            ClsshblddRepository = new ClasseHabilidadeRepository();
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ClsshblddRepository.ListarTodos());
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(ClsshblddRepository.BuscarPorID(id));
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            ClsshblddRepository.Cadastrar(novaClasseHabilidade);

            return StatusCode(201);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, ClasseHabilidade chAtualizada)
        {
            ClsshblddRepository.AtualizarURL(id, chAtualizada);

            return StatusCode(204);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            ClsshblddRepository.Deletar(id);

            return StatusCode(204);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        //[HttpGet("habilidades")]
        //public IActionResult ListarComHabilidades()
        //{
        //    return Ok(ClsshblddRepository.ListarComHabilidades());
        //}
    }
}
