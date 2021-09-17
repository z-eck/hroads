using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Atualizar( Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = ctx.Personagems.Find(personagemAtualizado.IdPersonagem);

            personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
            personagemBuscado.PtsMana = personagemAtualizado.PtsMana;
            personagemBuscado.PtsVida = personagemAtualizado.PtsVida;
            personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
            personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;

            ctx.Update(personagemBuscado);

            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int idPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(e => e.IdPersonagem == idPersonagem);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagems.Add(novoPersonagem);

            ctx.SaveChanges();
        }

        public void Deletar(int idPersonagem)
        {
            ctx.Personagems.Remove(BuscarPorId(idPersonagem));

            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodos()
        {
            return ctx.Personagems.OrderBy(e => e.NomePersonagem).ToList();
        }
    }
}
