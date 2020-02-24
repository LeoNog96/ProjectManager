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
        private readonly IProjectRepository _repoProject;

        public ActivityService(IActivityRepository repoActivity, IProjectRepository repoProject)
        {
            _repoActivity = repoActivity;
            _repoProject = repoProject;
        }

        public async Task Delete(long projectId, long activityId)
        {
            await _repoActivity.Delete(activityId);

            await AfterTransactionActivity(projectId);
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
            var newActivity = await _repoActivity.Save(activity);

            await AfterTransactionActivity(newActivity.ProjectId);

            newActivity.Project = null;

            return newActivity;
        }

        public async Task AfterTransactionActivity(long projectId)
        {
            var project = await _repoProject.GetByVerify(projectId);

            var activities = await GetAllByProject(project.Id);

            var percentActivities = CalcPercentComplete(activities.Count,
                activities.Where(x => x.Finished.Value).ToList().Count);

            var acDateBigger = activities.Find(x => x.FinalDate > project.FinalDate);

            bool isLate = acDateBigger != null;

            bool modify = false;

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

            if (modify)
            {
                await _repoProject.Update(project);
            }
        }

        public double CalcPercentComplete(int totalActivities, int finishedActivities)
        {
            return 100 - (((totalActivities - finishedActivities) * 100)  / totalActivities);
        }

        public async Task Update(Activity activity)
        {
            await _repoActivity.Update(activity);

            await AfterTransactionActivity(activity.ProjectId);
        }
    }
}