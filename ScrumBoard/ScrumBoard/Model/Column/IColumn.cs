namespace ScrumBoard;

public interface IColumn
{
    public void AddTask(ITask task);
    public void RemoveTask(Guid id_task);
    public ITask? GetTaskById(Guid id_task);
    public string Title { set; get; }
    public List<ITask> Tasks { get; }
    public Guid Id { get; }
}
