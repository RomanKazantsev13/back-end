namespace ScrumBoard;

public interface ITask
{
    public enum TaskPriority
    {
        Lowest = 1,
        BelowNormal,
        Normal,
        AboveNormal,
        Highest
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public ITask.TaskPriority Priority { get; set; }
    public Guid Id { get; }
}
