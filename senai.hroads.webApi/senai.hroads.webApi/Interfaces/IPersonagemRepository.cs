using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo PersonagemRepository
    /// </summary>
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os personagens existentes
        /// </summary>
        /// <returns></returns>
        List<Personagem> ListarTodos();

        /// <summary>
        /// Busca um personagem por meio do seu id
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será buscado</param>
        /// <returns>Um personagem encontrado</returns>
        Personagem BuscarPorId(int idPersonagem);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com os dados que serão cadastrados</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="personagemAtualizado">objeto personagemAtualizado com os dados que serão atualizados</param>
        void Atualizar(Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será deletado</param>
        void Deletar(int idPersonagem);
    }
}
