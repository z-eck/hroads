using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void AtualizarUsuario(Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(usuarioAtualizado.IdUsuario);

            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.Include(e => e.IdTipoUsuarioNavigation).FirstOrDefault(e => e.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            //return ctx.Usuarios.ToList();
            return ctx.Usuarios.Include(e => e.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
