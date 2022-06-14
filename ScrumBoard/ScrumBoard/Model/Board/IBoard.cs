namespace ScrumBoard;

public interface IBoard
{
    public string Title { get; }
    public List<IColumn> Columns { get; }
    public Guid Id { get; }

    public void AddColumn(IColumn column);
    public void RemoveColumn(Guid? id_column);
    public void AddTask(ITask task);
    public void RemoveTask(Guid? id_task);
    public ITask? GetTask(Guid? id_task);
    public List<ITask> GetAllTask(Guid? id_column);
    public void MoveTask(Guid? id_column, Guid? id_task);
}
