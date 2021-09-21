using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>A lista com todas as classes</returns>
        List<Classe> ListarTodos();

        /// <summary>
        /// Busca pelo ID uma classe em específica
        /// </summary>
        /// <param name="idClasse">ID da classe que será utilizada para a busca</param>
        /// <returns>A classe buscada pela ID</returns>
        Classe BuscarPorID(int idClasse);

        /// <summary>
        /// Registra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto utilizado para nomear a nova classe</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualizará uma informação, sendo buscada pela URL
        /// </summary>
        /// <param name="idClasse">ID da classe que será utilizada para a identificação de qual ID que será atualizada</param>
        /// <param name="classeAtualizada">Objeto que estará no corpo da requisição que servirá para ser atualizado</param>
        void AtualizarURL(int idClasse, Classe classeAtualizada);

        /// <summary>
        /// Deletará uma classe
        /// </summary>
        /// <param name="idClasse">ID da classe que será utilizada para a remoção de uma informação</param>
        void Deletar(int idClasse);

        /// <summary>
        /// Listará todas as classes, com os personagens onde estão inclusas
        /// </summary>
        /// <returns>A lista com todas as classes, com os personagens</returns>
        List<Classe> ListarComPersonagem();
    }
}
