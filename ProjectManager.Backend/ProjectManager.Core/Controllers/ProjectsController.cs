using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Services.Interfaces;
using ProjectManager.Entities.Models;

namespace ProjectManager.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet("{id:long}", Name="GetProject")]
        public async Task<ActionResult<Project>> Get(long id)
        {
            var project = await _service.Get(id);

            return project ?? (ActionResult<Project>)NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Post(Project project)
        {
            try
            {
                var newProject = await _service.Save(project);

                return CreatedAtRoute("GetProject", new {id = newProject.Id}, newProject);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Project project)
        {
            try
            {
                await _service.Update(project);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _service.Delete(id);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all", Name="GetProjects")]
        public async Task<ActionResult<List<Project>>> GetAll()
        {
            var project = await _service.GetAll();

            if (project.Count == 0 || project == null)
            {
                return NotFound();
            }

            return project;
        }
    }
}