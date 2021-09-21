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
        readonly HROADSContext context = new();

        public void AtualizarURL(int idHabilidade, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadePesquisada = context.Habilidades.Find(idHabilidade);

            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                habilidadePesquisada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;

                context.Habilidades.Update(habilidadePesquisada);

                context.SaveChanges();
            }
        }

        public Habilidade BuscarPorID(int idHabilidade)
        {
            return context.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).Include(h => h.ClasseHabilidades).FirstOrDefault(h => h.IdHabilidade == idHabilidade);
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

        public List<Habilidade> ListarTodos()
        {
            return context.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).Include(h => h.ClasseHabilidades).ToList();
        }
    }
}
