using tsk.Domain.Enums;

namespace tsk.Domain.Models
{
    public class TaskItem
    {
        public TaskItem(Guid id, string title, string description, DateTime dueDate, TaskStatus status, TaskPriority priority)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
            Comments = new List<TaskComment>();
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public TaskStatus Status { get; private set; }
        public TaskPriority Priority { get; private set; }
        public List<TaskComment> Comments { get; private set; }
    }
}