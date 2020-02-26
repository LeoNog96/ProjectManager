using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectManager.Entities.Models;

namespace ProjectManager.Repositories.Interfaces
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        Task<List<Activity>> GetAllByProject(long projectId);
        Task UpdateProject(Project project);
        Task<Project> GetProject(long projectId);
    }
}