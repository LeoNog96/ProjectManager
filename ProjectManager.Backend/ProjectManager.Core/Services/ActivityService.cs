using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActivityManager.Core.Services.Interfaces;
using ProjectManager.Entities.Models;
using ProjectManager.Repositories.Interfaces;

namespace ProjectManager.Core.Services
{
    public class ActivityService : IActivityService
    {
        private IActivityRepository _repoActivity;
        private IProjectRepository _repoProject;

        public ActivityService(IActivityRepository repoActivity, IProjectRepository repoProject)
        {
            _repoActivity = repoActivity;
            _repoProject = repoProject;
        }

        public Task Delete(long ActivityId)
        {
            throw new System.NotImplementedException();
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

            await PosSaveOrUpdateActivity(newActivity);

            return newActivity;
        }

        public async Task PosSaveOrUpdateActivity(Activity activity)
        {
            var project = await _repoProject.Get(activity.ProjectId);

            if (activity.FinalDate > project.FinalDate)
            {
                project.Late = true;

                await _repoProject.Update(project);
            }
        }

        public async Task Update(Activity activity)
        {
            await _repoActivity.Update(activity);

            await PosSaveOrUpdateActivity(activity);
        }
    }
}