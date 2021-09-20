using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pela entidade "TipoHabilidade"
    /// </summary>
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista Todos os tipos de habilidades
        /// </summary>
        /// <returns>A lista com todos os tipos de habilidades</returns>
        List<TipoHabilidade> ListarTodos();

        /// <summary>
        /// Busca pelo ID um tipo de habilidade em específico
        /// </summary>
        /// <param name="idTipoHabilidade">ID do tipo habilidade que será utilizado para a busca</param>
        /// <returns>O tipo de habilidade buscado pela ID</returns>
        TipoHabilidade BuscarPorID(int idTipoHabilidade);

        /// <summary>
        /// Registra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">Objeto utilizado para nomear o novo tipo de habilidade</param>
        void Cadastrar(TipoHabilidade novoTipo);

        /// <summary>
        /// Atualizará uma informação, sendo buscada pela URL
        /// </summary>
        /// <param name="idTipoHabilidade">ID do tipo de habilidade que será utilizado para a identificação de qual ID que será atualizada</param>
        /// <param name="tipoAtualizado">Objeto que estará no corpo da requisição que servirá para ser atualizado</param>
        void AtualizarURL(int idTipoHabilidade, TipoHabilidade tipoAtualizado);

        /// <summary>
        /// Deletará um tipo de habilidade
        /// </summary>
        /// <param name="idTipoHabilidade">ID do tipo de habilidade que será utilizado para a remoção de uma informação</param>
        void Deletar(int idTipoHabilidade);

        /// <summary>
        /// Listará todos os tipos, com as habilidades "linkadas"
        /// </summary>
        /// <returns>A lista com todos os tipos de habilidades com as habilidades</returns>
        List<TipoHabilidade> ListarComHabilidades();
    }
}
