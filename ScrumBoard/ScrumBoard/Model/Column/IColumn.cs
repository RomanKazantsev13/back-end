namespace ScrumBoard;

public interface IColumn
{
    public string Title { set; get; }
    public List<ITask> Tasks { get; }
    public Guid Id { get; }

    public void AddTask(ITask task);
    public void RemoveTask(Guid? id_task);
    public ITask? GetTask(Guid? id_task);
}
