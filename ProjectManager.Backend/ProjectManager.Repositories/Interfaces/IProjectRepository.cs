using System.Threading.Tasks;
using ProjectManager.Entities.Models;

namespace ProjectManager.Repositories.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task DeleteProject(long projectId);
    }
}