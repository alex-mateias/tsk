using Microsoft.AspNetCore.Mvc;
using tsk.Domain.Interfaces;
using tsk.Domain.Models;

namespace tsk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly IService<TaskItem> _taskItemService;

        public TaskItemsController(IService<TaskItem> taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(Guid id)
        {
            var taskItem = await _taskItemService.GetAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return Ok(taskItem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetAllTaskItems()
        {
            var taskItems = await _taskItemService.GetAllAsync();
            return Ok(taskItems);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTaskItem(TaskItem taskItem)
        {
            var createdTaskItem = await _taskItemService.AddAsync(taskItem);
            return CreatedAtAction(nameof(GetTaskItem), new { id = createdTaskItem.Id }, createdTaskItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskItem(Guid id, TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return BadRequest();
            }

            await _taskItemService.UpdateAsync(taskItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(Guid id)
        {
            await _taskItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}