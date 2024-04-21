using tsk.Domain.Models;

namespace tsk.Domain.Interfaces
{
    public interface ITaskItemService
    {
        Task<TaskItem> GetTaskItemAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync();
        Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem);
        Task UpdateTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync(Guid id);
    }
}
