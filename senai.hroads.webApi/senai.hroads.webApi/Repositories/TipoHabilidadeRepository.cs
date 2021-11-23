using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        readonly HRoadsContext context = new();

        public void AtualizarURL(int idTipoHabilidade, TipoHabilidade tipoAtualizado)
        {

            TipoHabilidade tipoPesquisado = context.TipoHabilidades.Find(idTipoHabilidade);

            if (tipoAtualizado.NomeTipoHabilidade != null)
            {
                tipoPesquisado.NomeTipoHabilidade = tipoAtualizado.NomeTipoHabilidade;

                context.TipoHabilidades.Update(tipoPesquisado);

                context.SaveChanges();
            }

        }

        public TipoHabilidade BuscarPorID(int idTipoHabilidade)
        {
            return context.TipoHabilidades.Include(t => t.Habilidades).FirstOrDefault(t => t.IdTipoHabilidade == idTipoHabilidade);
        }

        public void Cadastrar(TipoHabilidade novoTipo)
        {
            context.TipoHabilidades.Add(novoTipo);

            context.SaveChanges();

        }
        public void Deletar(int idTipoHabilidade)
        {
            context.TipoHabilidades.Remove(BuscarPorID(idTipoHabilidade));

            context.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodos()
        {
            return context.TipoHabilidades.Include(t => t.Habilidades).ToList();
        }
    }
}
