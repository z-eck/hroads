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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        readonly HRoadsContext context = new();

        public void Atualizar(Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadePesquisada = context.Habilidades.Find(habilidadeAtualizada.IdHabilidade);

            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                habilidadePesquisada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;

                context.Habilidades.Update(habilidadePesquisada);

                context.SaveChanges();
            }
        }

        public Habilidade BuscarPorID(int idHabilidade)
        {
            return context.Habilidades.FirstOrDefault(h => h.IdHabilidade == idHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            context.Habilidades.Add(novaHabilidade);

            context.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            context.Habilidades.Remove(BuscarPorID(idHabilidade));

            context.SaveChanges();
        }

        public List<Habilidade> ListarComClasseHabilidades()
        {
            return context.Habilidades.Include(h => h.ClasseHabilidades).ToList();
        }

        public List<Habilidade> ListarComTipoHabilidades()
        {
            return context.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).ToList();
        }

        public List<Habilidade> ListarTodos()
        {
            return context.Habilidades.ToList();
        }
    }
}
