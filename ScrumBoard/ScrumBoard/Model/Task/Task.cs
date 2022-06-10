namespace ScrumBoard;

public class Task : ITask
{
    public Task(string title, string description, ITask.TaskPriority priority)
    {
        Title = title;
        Description = description;
        Priority = priority;
        Id = Guid.NewGuid();
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public ITask.TaskPriority Priority { get; set; }
    public Guid Id { get; }
}
