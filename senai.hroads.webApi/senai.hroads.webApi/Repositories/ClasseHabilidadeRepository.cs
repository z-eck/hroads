using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {

        readonly HROADSContext context = new();

        public void AtualizarURL(int idClasseHabilidade, ClasseHabilidade chAtualizada)
        {
            
            ClasseHabilidade chPesquisada = context.ClasseHabilidades.Find(idClasseHabilidade);

            if (chAtualizada.IdClasseHabilidade != null)
            {
                chPesquisada.IdClasseHabilidade = chAtualizada.IdClasseHabilidade;

                context.ClasseHabilidades.Update(chPesquisada);

                context.SaveChanges();
              }
        }

        public ClasseHabilidade BuscarPorID(int idClasseHabilidade)
        {
            return context.ClasseHabilidades.FirstOrDefault(c => c.IdClasseHabilidade == idClasseHabilidade);
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
            return context.ClasseHabilidades.ToList();
        }
        
        public List<ClasseHabilidade> ListarComHabilidades()
        {
            return context.Classes.Include(ch => ch.IdHabilidadeNavegation).ToList();
        }
        
        public List<ClasseHabilidade> ListarComClasse()
        {
            return context.ClasseHabilidades.Include(ch => ch.Classes).ToList();
        }
    }
}
