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
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Post(Project project)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Project project)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("all", Name="GetProjects")]
        public async Task<ActionResult<List<Project>>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}