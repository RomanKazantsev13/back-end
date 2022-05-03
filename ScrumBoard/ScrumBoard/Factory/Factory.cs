namespace ScrumBoard;
public class Factory
{
    public static IBoard CreateBoard(string title)
    {
        return new Board(title);
    }

    public static IColumn CreateColumn(string title)
    {
        return new Column(title);
    }

    public static ITask CreateTask(string title, string description, ITask.Priority priority)
    {
        return new Task(title, description, priority);
    }
}
