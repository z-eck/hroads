using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {

        readonly HRoadsContext context = new();

        public void AtualizarURL(int idClasseHabilidade, ClasseHabilidade chAtualizada)
        {
            
            ClasseHabilidade chPesquisada = context.ClasseHabilidades.Find(idClasseHabilidade);

            if (chAtualizada.IdHabilidadeNavigation != null || chAtualizada.IdClasseNavigation != null)
            {
                chPesquisada.IdHabilidadeNavigation = chAtualizada.IdHabilidadeNavigation;
                chPesquisada.IdClasseNavigation = chAtualizada.IdClasseNavigation;

                context.ClasseHabilidades.Update(chPesquisada);

                context.SaveChanges();
            }
        }

        public ClasseHabilidade BuscarPorID(int idClasseHabilidade)
        {
            return context.ClasseHabilidades.Include(ch => ch.IdClasseNavigation).Include(ch => ch.IdHabilidadeNavigation).FirstOrDefault(c => c.IdClasseHabilidade == idClasseHabilidade);
        }

        public void Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            context.ClasseHabilidades.Add(novaClasseHabilidade);

            context.SaveChanges();
        }

        public void Deletar(int idClasseHabilidade)
        {
            context.ClasseHabilidades.Remove(BuscarPorID(idClasseHabilidade));

            context.SaveChanges();
        }

        public List<ClasseHabilidade> ListarTodos()
        {
            return context.ClasseHabilidades.Include(ch => ch.IdClasseNavigation).Include(ch => ch.IdHabilidadeNavigation).ToList();
        }
    }
}
