namespace ScrumBoard;

public class Board : IBoard
{
    public string Title { get; }
    public List<IColumn> Columns { get; }
    private Guid Id = Guid.NewGuid();

    public Board(string title)
    {
        Title = title;
        Columns = new List<IColumn>();
    }

    public void AddColumn(string title)
    {
        if (Columns.Count() >= 10)
        {
            return;
        }

        IColumn column = Factory.CreateColumn(title);
        Columns.Add(column);
    }

    public void RemoveColumn(Guid id_column)
    {
        IColumn? column = GetColumnById(id_column);

        if (column != null)
        {
            Columns.Remove(column);
        }
    }

    public void AddTask(string title, string description, ITask.TaskPriority priority)
    {
        ITask task = Factory.CreateTask(title, description, priority);
        Columns[0].AddTask(task);
    }

    public void MoveTask(Guid id_column, Guid id_task)
    {
        ITask? task = null;

        foreach (IColumn column in Columns)
        {
            task = column.GetTaskById(id_task);
            if (task != null)
            {
                column.RemoveTask(task.Id);
                break;
            }
        }

        IColumn? newColumn = GetColumnById(id_column);

        if (newColumn != null && task != null)
        {
            newColumn.AddTask(task);
        }
    }

    private IColumn? GetColumnById(Guid id_column)
    {
        foreach (IColumn column in Columns)
        {
            if (column.Id == id_column)
            {
                return column;
            }
        }
        return null;
    }
}
