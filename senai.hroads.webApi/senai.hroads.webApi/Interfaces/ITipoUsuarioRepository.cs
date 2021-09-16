using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista de todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de todos os tipos de usuário existentes</returns>
        List<TipoUsuario> ListarTodos();
        
        /// <summary>
        /// Busca um tipo de usuário por meio do seu id
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipo de usuário que será buscado</param>
        /// <returns></returns>
        TipoUsuario BuscarPorId(int idTipoUsuario);

        /// <summary>
        /// Cadastra um novo tipo de usuario no sistema
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com seus dados</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um tipo de usuário cadastrado
        /// </summary>
        /// <param name="TipoUsuarioAtual">Objeto tipoAtualizado com seus novos dados atualizados</param>
        void Atualizar(TipoUsuario TipoUsuarioAtual);

        /// <summary>
        /// Deleta um tipo de usuário do sistema
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipoUsuario que será deletado</param>
        void Deletar(int idTipoUsuario);
    }
}
