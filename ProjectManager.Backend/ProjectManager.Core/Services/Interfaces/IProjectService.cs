using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Entities.Models;

namespace ProjectManager.Core.Services.Interfaces
{
    public interface IProjectService
    {
        /// <summary>
        /// Salva um Projeto
        /// </summary>
        /// <param name="project"> Projeto a ser salvo </param>
        /// <returns>Retorna o Projeto já persistida no banco</returns>
        Task<Project> Save(Project project);

        /// <summary>
        /// Busca determinado Projeto
        /// </summary>
        /// <param name="projectId"> id do projeto ser buscado </param>
        /// <returns> Retorna um projeto com id igual ao parametro</returns>
        Task<Project> Get(long projectId);

        /// <summary>
        /// Lista todos os Projetos
        /// </summary>
        /// <returns> Retorna uma lista com todos os Projetos</returns>
        Task<List<Project>> GetAll();

        /// <summary>
        /// Atualiza um Projeto
        /// </summary>
        /// <param name="project">Projeto a ser atualizado</param>
        Task Update(Project project);

        /// <summary>
        /// Remove um Projeto
        /// </summary>
        /// <param name="projectId">Id do Projeto a ser removida</param>
        Task Delete(long projectId);
    }
}