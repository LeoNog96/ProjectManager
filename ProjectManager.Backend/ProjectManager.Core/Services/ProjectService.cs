using System;
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
            var project = await _repository.Get(projectId);

            return project.Removed.Value ? null : project;
        }

        public async Task<List<Project>> GetAll()
        {
            var all =  await _repository.GetAll();

            return all.Where(x => !x.Removed.Value).ToList();
        }

        public async Task<Project> Save(Project project)
        {
            ValidDateProject(project.InitialDate, project.FinalDate);

            return await _repository.Save(project);
        }

        /// <summary>
        /// Valida Se a Data inicial é menor que a data final do projeto
        /// </summary>
        /// <param name="initialDate"> Data inicial do projeto</param>
        /// <param name="finalDate"> Data final do projeto</param>
        public void ValidDateProject(DateTime initialDate, DateTime finalDate)
        {
            if(finalDate < initialDate)
            {
                throw new Exception("Data final não pode ser menor que a data inicial do projeto");
            }
        }

        public async Task Update(Project project)
        {
            ValidDateProject(project.InitialDate, project.FinalDate);

            await _repository.Update(project);
        }
    }
}