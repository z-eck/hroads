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

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(HblddRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(HblddRepository.BuscarPorID(id));
        }

        //[Authorize(Roles = "1)]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabilidade)
        {
            HblddRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        //[Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult AtualizarURL(Habilidade habilidadeAtualizada)
        {
            HblddRepository.Atualizar(habilidadeAtualizada);

            return StatusCode(204);
        }

        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            HblddRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpGet("tipohabilidades")]
        public IActionResult ListarComTipoHabilidades()
        {
            return Ok(HblddRepository.ListarComTipoHabilidades());
        }


        [HttpGet("classehabilidades")]
        public IActionResult ListarComClasseHabilidades()
        {
            return Ok(HblddRepository.ListarComClasseHabilidades());
        }
    }
}
