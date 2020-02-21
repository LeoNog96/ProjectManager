using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Entities.Models;

namespace ActivityManager.Core.Services.Interfaces
{
    public interface IActivityService
    {
        /// <summary>
        /// Salva uma Atividade
        /// </summary>
        /// <param name="activity"> Atividade a ser salvo </param>
        /// <returns>Retorna a Atividade já persistida no banco</returns>
        Task<Activity> Save(Activity activity);

        /// <summary>
        /// Busca determinada Atividade
        /// </summary>
        /// <param name="activityId"> id da Atividade ser buscada </param>
        /// <returns> Retorna uma Atividade com id igual ao parametro</returns>
        Task<Activity> Get(long activityId);

        /// <summary>
        /// Lista todos as Atividades
        /// </summary>
        /// <param name="projectId"> id do projeto relacionada as atividades </param>
        /// <returns> Retorna uma Atividade com id igual ao parametro</returns>
        /// <returns> Retorna uma lista com todas Atividades</returns>
        Task<List<Activity>> GetAllByProject(long projectId);

        /// <summary>
        /// Atualiza uma Atividade
        /// </summary>
        /// <param name="activity">Atividade a ser atualizada</param>
        Task Update(Activity activity);

        /// <summary>
        /// Remove uma Atividade
        /// </summary>
        /// <param name="projectId">Id do projeto da Atividade a ser removida</param>
        /// <param name="activityId">Id da Atividade a ser removida</param>
        Task Delete(long projectId, long activityId);
    }
}