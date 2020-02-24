using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Core.Services.Interfaces;
using ProjectManager.Entities.Models;
using ProjectManager.Repositories.Interfaces;

namespace ProjectManager.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(long projectId)
        {
            await _repository.DeleteProject(projectId);
        }

        public async Task<Project> Get(long projectId)
        {
            return await _repository.Get(projectId);
        }

        public async Task<List<Project>> GetAll()
        {
            var all =  await _repository.GetAll();

            return all.Where(x => !x.Removed.Value).ToList();
        }

        public async Task<Project> Save(Project project)
        {
            return await _repository.Save(project);
        }

        public async Task Update(Project project)
        {
            await _repository.Update(project);
        }
    }
}