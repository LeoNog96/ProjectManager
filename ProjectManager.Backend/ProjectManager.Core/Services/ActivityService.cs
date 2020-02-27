using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivityManager.Core.Services.Interfaces;
using ProjectManager.Entities.Models;
using ProjectManager.Repositories.Interfaces;

namespace ProjectManager.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _repoActivity;

        public ActivityService(IActivityRepository repoActivity)
        {
            _repoActivity = repoActivity;
        }

        public async Task Delete(long projectId, long activityId)
        {
            await _repoActivity.Delete(activityId);

            var project = await _repoActivity.GetProject(projectId);

            await AfterTransactionActivity(project);
        }

        public async Task<Activity> Get(long activityId)
        {
            return await _repoActivity.Get(activityId);
        }

        public async Task<List<Activity>> GetAllByProject(long projectId)
        {
            return await _repoActivity.GetAllByProject(projectId);
        }

        public async Task<Activity> Save(Activity activity)
        {
            var project = await _repoActivity.GetProject(activity.ProjectId);

            ValidDates(activity.InitialDate, project.InitialDate);

            ValidDateActivity(activity.InitialDate, activity.FinalDate);

            var newActivity = await _repoActivity.Save(activity);

            await AfterTransactionActivity(project);

            newActivity.Project = null;

            return newActivity;
        }

        /// <summary>
        /// Valida Se a Data da atividade é menor que a data inicial do projeto
        /// </summary>
        /// <param name="initialDateA"> Data inicial da Atividade</param>
        /// <param name="initialDateP"> Data inicial do projeto</param>
        public void ValidDates(DateTime initialDateA, DateTime initialDateP)
        {
            if (initialDateA < initialDateP)
            {
                throw new Exception("Data inicial da Atividade não pode ser menor que data inicial do projeto");
            }
        }

        /// <summary>
        /// Valida Se a Data inicial é menor que a data final da atividade
        /// </summary>
        /// <param name="initialDate"> Data inicial da Atividade</param>
        /// <param name="finalDate"> Data final da Atividade</param>

        public void ValidDateActivity(DateTime initialDate, DateTime finalDate)
        {
            if(finalDate < initialDate)
            {
                throw new Exception("Data final não pode ser menor que a data inicial da atividade");
            }
        }

        /// <summary>
        /// Funciona como um gatilho após as operações de persistencia, atualização e exclusão
        /// para verificar a porcentagem complesta e se o projeto está atrasado
        /// </summary>
        /// <param name="project"> Objeto do projeto</param>
        public async Task AfterTransactionActivity(Project project)
        {
            var activities = await GetAllByProject(project.Id);

            bool modify = false;

            if (activities.Count != 0)
            {
                var percentActivities = CalcPercentComplete(activities.Count,
                    activities.Where(x => x.Finished.Value).ToList().Count);

                var acDateBigger = activities.Find(x => x.FinalDate > project.FinalDate);

                bool isLate = acDateBigger != null;

                if (project.PercentComplete != percentActivities)
                {
                    project.PercentComplete = percentActivities;

                    modify = true;
                }

                if (project.Late != isLate)
                {
                    project.Late = isLate;

                    modify = true;
                }
            }
            else
            {
                project.Late = false;

                project.PercentComplete = 0;

                modify = true;
            }

            if (modify)
            {
                await _repoActivity.UpdateProject(project);
            }
        }

        /// <summary>
        /// Calcula a porcentagem completa do do projeto
        /// </summary>
        /// <param name="totalActivities"> total de atividades do projeto</param>
        /// <param name="finishedActivities">total de atividades finalizadas no projeto</param>
        public double CalcPercentComplete(int totalActivities, int finishedActivities)
        {
            return 100 - (((totalActivities - finishedActivities) * 100)  / totalActivities);
        }

        public async Task Update(Activity activity)
        {
            var project = await _repoActivity.GetProject(activity.ProjectId);

            ValidDates(activity.InitialDate, project.InitialDate);

            ValidDateActivity(activity.InitialDate, activity.FinalDate);

            await _repoActivity.Update(activity);

            await AfterTransactionActivity(project);
        }
    }
}