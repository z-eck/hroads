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
    public class ClasseRepository : IClasseRepository
    {

        readonly HRoadsContext context = new();

        public void AtualizarURL(int idClasse, Classe classeAtualizada)
        {
            Classe classePesquisada = context.Classes.Find(idClasse);

            if (classeAtualizada.NomeClasse != null)
            {
                classePesquisada.NomeClasse = classeAtualizada.NomeClasse;

                context.Classes.Update(classePesquisada);

                context.SaveChanges();
            }
        }

        public Classe BuscarPorID(int idClasse)
        {
            return context.Classes.Include(c => c.Personagems).Include(c => c.ClasseHabilidades).FirstOrDefault(c => c.IdClasse == idClasse);
        }

        public void Cadastrar(Classe novaClasse)
        {
            context.Classes.Add(novaClasse);

            context.SaveChanges();
        }

        public void Deletar(int idClasse)
        {
            context.Classes.Remove(BuscarPorID(idClasse));

            context.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            return context.Classes.OrderBy(c => c.NomeClasse).Include(c => c.Personagems).Include(c => c.ClasseHabilidades).ToList();
        }
    }
}
