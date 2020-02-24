using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.Models;
using ProjectManager.Repositories.Interfaces;

namespace ProjectManager.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectManagerContext db)
            :base(db)
        {
        }

        public async Task<Project> GetByVerify(long projectId)
        {
            return await _db.Projects.FindAsync(projectId);
        }

        public async Task DeleteProject(long projectId)
        {
            var entity = await Get(projectId);

            entity.Removed = true;

            await Update(entity);
        }
    }
}