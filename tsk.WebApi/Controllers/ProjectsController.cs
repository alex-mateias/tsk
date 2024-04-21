using Microsoft.AspNetCore.Mvc;
using tsk.Domain.Interfaces;
using tsk.Domain.Models;

namespace tsk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IService<Project> _projectService;

        public ProjectsController(IService<Project> projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            var project = await _projectService.GetAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            var createdProject = await _projectService.AddAsync(project);
            return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            await _projectService.UpdateAsync(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _projectService.DeleteAsync(id);
            return NoContent();
        }
    }
}