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
    }
}