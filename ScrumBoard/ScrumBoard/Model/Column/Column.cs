namespace ScrumBoard;

public class Column : IColumn
{
    public string Title { set; get; }
    public List<ITask> Tasks { get; }
    public Guid Id { get; }

    public Column(string title)
    {
        Title = title;
        Tasks = new List<ITask>();
        Id = Guid.NewGuid();
    }

    public void AddTask(ITask task)
    {
        Tasks.Add(task);
    }

    public void RemoveTask(Guid? id_task)
    {
        ITask? task = GetTask(id_task);

        if (task != null)
        {
            Tasks.Remove(task);
        }
    }

    public ITask? GetTask(Guid? id_task)
    {
        foreach (ITask task in Tasks)
        {
            if (task.Id == id_task)
            {
                return task;
            }
        }

        return null;
    }
}
