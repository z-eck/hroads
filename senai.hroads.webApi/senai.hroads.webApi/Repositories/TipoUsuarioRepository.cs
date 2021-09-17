using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Atualizar(TipoUsuario TipoUsuarioAtual)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(TipoUsuarioAtual.IdTipoUsuario);

            tipoBuscado.Titulo = TipoUsuarioAtual.Titulo;

            ctx.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == idTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(idTipoUsuario));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
