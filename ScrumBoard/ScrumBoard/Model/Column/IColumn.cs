namespace ScrumBoard;

public interface IColumn
{
    public void AddTask(ITask task);
    public void RemoveTask(Guid id_task);
    public ITask? GetTaskById(Guid id_task);
    public string m_title { set; get; }
    public List<ITask> m_tasks { get; }
    public Guid m_id { get; }
}
