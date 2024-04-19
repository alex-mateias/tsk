namespace tsk.Domain.Models
{
    public class TaskComment
    {
        public TaskComment(Guid id, string comment, DateTime commentedAt)
        {
            Id = id;
            Comment = comment;
            CommentedAt = commentedAt;
        }

        public Guid Id { get; private set; }
        public string Comment { get; private set; }
        public DateTime CommentedAt { get; private set; }
    }
}