namespace ScrumBoard;

public interface IBoard
{
    public string Title { get; }
    public List<IColumn> Columns { get; }

    public void AddColumn(string title);
    public void RemoveColumn(Guid id_column);
    public void AddTask(string title, string description, ITask.TaskPriority priority);
    public void MoveTask(Guid id_column, Guid id_task);
}
