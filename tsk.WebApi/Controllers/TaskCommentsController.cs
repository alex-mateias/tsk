using Microsoft.AspNetCore.Mvc;
using tsk.Domain.Interfaces;
using tsk.Domain.Models;

namespace tsk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCommentsController : ControllerBase
    {
        private readonly IService<TaskComment> _taskCommentService;

        public TaskCommentsController(IService<TaskComment> taskCommentService)
        {
            _taskCommentService = taskCommentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskComment>> GetTaskComment(Guid id)
        {
            var taskComment = await _taskCommentService.GetAsync(id);
            if (taskComment == null)
            {
                return NotFound();
            }

            return Ok(taskComment);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskComment>>> GetAllTaskComments()
        {
            var taskComments = await _taskCommentService.GetAllAsync();
            return Ok(taskComments);
        }

        [HttpPost]
        public async Task<ActionResult<TaskComment>> CreateTaskComment(TaskComment taskComment)
        {
            var createdTaskComment = await _taskCommentService.AddAsync(taskComment);
            return CreatedAtAction(nameof(GetTaskComment), new { id = createdTaskComment.Id }, createdTaskComment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskComment(Guid id, TaskComment taskComment)
        {
            if (id != taskComment.Id)
            {
                return BadRequest();
            }

            await _taskCommentService.UpdateAsync(taskComment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskComment(Guid id)
        {
            await _taskCommentService.DeleteAsync(id);
            return NoContent();
        }
    }
}