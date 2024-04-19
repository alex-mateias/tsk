namespace tsk.Domain.Models
{
    public class TaskAssignment
    {
        public Guid Id { get; private set; }
        public Guid TodoId { get; private set; }
        public Guid AssigneeId { get; private set; }
        public TaskItem TaskItem { get; private set; }
        public User Assignee { get; private set; }
    }
}