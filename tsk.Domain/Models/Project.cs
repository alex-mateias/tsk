namespace tsk.Domain.Models
{
    public class Project
    {
        public Project(Guid id, string name, string description, DateTime dueDate)
        {
            Id = id;
            Name = name;
            Description = description;
            DueDate = dueDate;
            Members = new List<User>();
            TaskItems = new List<TaskItem>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public List<User> Members { get; private set; }
        public List<TaskItem> TaskItems { get; private set; }
    }
}
