using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    // ex: http://localhost:5000/api/TipoUsuarios
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
