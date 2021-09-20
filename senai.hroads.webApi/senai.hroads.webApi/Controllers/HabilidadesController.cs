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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository HblddRepository { get; set; }
        public HabilidadesController()
        {
            HblddRepository = new HabilidadeRepository();
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(HblddRepository.ListarTodos());
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(HblddRepository.BuscarPorID(id));
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabilidade)
        {
            HblddRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, Habilidade habilidadeAtualizada)
        {
            HblddRepository.AtualizarURL(id, habilidadeAtualizada);

            return StatusCode(204);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            HblddRepository.Deletar(id);

            return StatusCode(204);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("tipohabilidades")]
        public IActionResult ListarComTipoHabilidades()
        {
            return Ok(HblddRepository.ListarComTipoHabilidades());
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("classehabilidades")]
        public IActionResult ListarComClasseHabilidades()
        {
            return Ok(HblddRepository.ListarComClasseHabilidades());
        }
    }
}
