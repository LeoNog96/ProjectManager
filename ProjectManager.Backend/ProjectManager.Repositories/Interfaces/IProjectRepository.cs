using System.Threading.Tasks;
using ProjectManager.Entities.Models;

namespace ProjectManager.Repositories.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<Project> GetByVerify(long projectId);
        Task DeleteProject(long projectId);
    }
}