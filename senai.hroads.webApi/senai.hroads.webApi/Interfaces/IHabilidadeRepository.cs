using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pela entidade "Habilidade"
    /// </summary>
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>A lista com todas as habilidades</returns>
        List<Habilidade> ListarTodos();

        /// <summary>
        /// Busca pelo ID uma habilidade em específica
        /// </summary>
        /// <param name="idHabilidade">ID da habilidade que será utilizada para a busca</param>
        /// <returns>A habilidade buscada pela ID</returns>
        Habilidade BuscarPorID(int idHabilidade);

        /// <summary>
        /// Registra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto utilizado para nomear a nova habilidade</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualizará uma informação, sendo buscada pela URL
        /// </summary>
        /// <param name="idHabilidade">ID da habilidade que será utilizada para a identificação de qual ID que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto que estará no corpo da requisição que servirá para ser atualizado</param>
        void AtualizarURL(int idHabilidade, Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deletará uma habilidade
        /// </summary>
        /// <param name="idHabilidade">ID da habilidade que será utilizada para a remoção de uma informação</param>
        void Deletar(int idHabilidade);
    }
}
