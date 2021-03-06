using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.Models;
using ProjectManager.Repositories.Interfaces;

namespace ProjectManager.Repositories
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ProjectManagerContext db)
            :base(db)
        {
        }

        public async Task<List<Activity>> GetAllByProject(long projectId)
        {
            return await _db.Activities.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public async Task<Project> GetProject(long projectId)
        {
            return await _db.Projects.FindAsync(projectId);
        }

        public async Task UpdateProject(Project project)
        {
            _db.Projects.Update(project);

            await _db.SaveChangesAsync();
        }
    }
}