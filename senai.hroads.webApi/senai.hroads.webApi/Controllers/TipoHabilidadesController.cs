using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository TphblddRepository { get; set; }
        public TipoHabilidadesController()
        {
            TphblddRepository = new TipoHabilidadeRepository();
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TphblddRepository.ListarTodos());
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(TphblddRepository.BuscarPorID(id));
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novoTipo)
        {
            TphblddRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, TipoHabilidade tipoAtualizado)
        {
            TphblddRepository.AtualizarURL(id, tipoAtualizado);

            return StatusCode(204);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            TphblddRepository.Deletar(id);

            return StatusCode(204);
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("habilidades")]
        public IActionResult ListarComHabilidades()
        {
            return Ok(TphblddRepository.ListarComHabilidades());
        }
    }
}
