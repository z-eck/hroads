using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        public void Atualizar(int idPersonagem, Personagem personagemAtualizado)
        {
            throw new NotImplementedException();
        }

        public Personagem BuscarPorId(int idPersonagem)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idPersonagem)
        {
            throw new NotImplementedException();
        }

        public List<Personagem> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
