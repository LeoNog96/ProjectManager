using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActivityManager.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Services.Interfaces;
using ProjectManager.Entities.Models;

namespace ActivityManager.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _service;

        public ActivitiesController(IActivityService service)
        {
            _service = service;
        }

        [HttpGet("{id:long}", Name="GetActivity")]
        public async Task<ActionResult<Activity>> Get(long id)
        {
            var activity = await _service.Get(id);

            return activity ?? (ActionResult<Activity>)NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Activity>> Post(Activity activity)
        {
            try
            {
                var newActivity = await _service.Save(activity);

                return CreatedAtRoute("GetActivity", new {id = newActivity.Id}, newActivity);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Activity activity)
        {
            try
            {
                await _service.Update(activity);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
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

        [HttpGet("all-by-project/{projectId:long}", Name="GetAllByProject")]
        public async Task<ActionResult<List<Activity>>> GetAllByProject(long projectId)
        {
            var activities = await _service.GetAllByProject(projectId);

            if (activities.Count == 0 || activities == null)
            {
                return NotFound();
            }

            return activities;
        }
    }
}