using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo Usuario no sistema
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com seus dados</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Lista todos os usuarios cadastrado
        /// </summary>
        /// <returns>Lista de todos os usuarios cadastrado</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Atualiza um usuario cadastrado
        /// </summary>
        /// <param name="usuarioAtualizado">objeto usuarioAtualizado com os dados atualizados</param>
        void AtualizarUsuario(Usuario usuarioAtualizado);

        /// <summary>
        /// Busca um usuário por meio de seu Id
        /// </summary>
        /// <param name="idUsuario">Id do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Deleta um usuário cadastrado
        /// </summary>
        /// <param name="idUsuario">Id do usuário que será deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>Retorna um usuário encontrado</returns>
        Usuario Login(string email, string senha);
    }
}
