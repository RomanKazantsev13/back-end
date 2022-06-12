namespace ScrumBoard;

public class Board : IBoard
{
    public string Title { get; }
    public List<IColumn> Columns { get; }
    public Guid Id { get; }

    public Board(string title)
    {
        Title = title;
        Columns = new List<IColumn>();
        Id = Guid.NewGuid();
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

    public void RemoveColumn(Guid? id_column)
    {
        IColumn? column = GetColumn(id_column);

        if (column != null)
        {
            Columns.Remove(column);
        }
    }

    private IColumn? GetColumn(Guid? id_column)
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

    public void AddTask(string title, string description, ITask.TaskPriority priority)
    {
        if (Columns.Count() <= 0)
        {
            return;
        }

        ITask task = Factory.CreateTask(title, description, priority);
        Columns[0].AddTask(task);
    }
    public void RemoveTask(Guid? id_task)
    {
        foreach (IColumn column in Columns)
        {
            column.RemoveTask(id_task);
        }
    }

    public ITask? GetTask(Guid? id_task)
    {
        ITask? task = null;
        foreach (IColumn column in Columns)
        {
            task = column.GetTask(id_task);

            if (task != null)
            {
                return task;
            }
        }

        return task;
    }

    public List<ITask> GetAllTask(Guid? id_column)
    {
        List<ITask> tasks = new List<ITask>();

        foreach (IColumn column in Columns)
        {
            if (column.Id == id_column)
            {
                tasks = column.Tasks;
            }
        }

        return tasks;
    }

    public void MoveTask(Guid? id_column, Guid? id_task)
    {
        ITask? task = null;

        foreach (IColumn column in Columns)
        {
            task = column.GetTask(id_task);
            if (task != null)
            {
                column.RemoveTask(task.Id);
                break;
            }
        }

        IColumn? newColumn = GetColumn(id_column);

        if (newColumn != null && task != null)
        {
            newColumn.AddTask(task);
        }
    }
}
