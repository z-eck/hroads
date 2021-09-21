using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pela entidade "ClasseHabilidade"
    /// </summary>
    interface IClasseHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as classes-habilidades
        /// </summary>
        /// <returns>A lista com todas as classes-habilidades</returns>
        List<ClasseHabilidade> ListarTodos();

        /// <summary>
        /// Busca pelo ID uma classe-habilidade em específica
        /// </summary>
        /// <param name="idClasseHabilidade">ID da classe-habilidade que será utilizada para a busca</param>
        /// <returns>A classe-habilidade buscada pela ID</returns>
        ClasseHabilidade BuscarPorID(int idClasseHabilidade);

        /// <summary>
        /// Registra uma nova classe-habilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto utilizado para nomear a nova classe-habilidade</param>
        void Cadastrar(ClasseHabilidade novaClasseHabilidade);

        /// <summary>
        /// Atualizará uma informação, sendo buscada pela URL
        /// </summary>
        /// <param name="idClasseHabilidade">ID da classe-habilidade que será utilizada para a identificação de qual ID que será atualizada</param>
        /// <param name="chAtualizada">Objeto que estará no corpo da requisição que servirá para ser atualizado</param>
        void AtualizarURL(int idClasseHabilidade, ClasseHabilidade chAtualizada);

        /// <summary>
        /// Deletará uma classe-habilidade
        /// </summary>
        /// <param name="idClasseHabilidade">ID da classe-habilidade que será utilizada para a remoção de uma informação</param>
        void Deletar(int idClasseHabilidade);
       
        /// <summary>
        /// Listará todas as classe-habilidade, com as classes onde estão inclusas
        /// </summary>
        /// <returns>A lista com todas as classe-habilidades, com as classes</returns>
        List<ClasseHabilidade> ListarComClasseHabilidade();
    }
}
