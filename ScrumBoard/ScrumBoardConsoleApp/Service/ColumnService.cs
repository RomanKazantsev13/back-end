namespace ScrumBoardConsoleApp;

using ScrumBoard;
using ScrumBoardConsoleApp.Data;

public class ColumnService
{
    private IColumn _column;

    public ColumnService(IColumn column)
    {
        _column = column;
    }

    public void AddTask()
    {
        string title = TaskData.GetTitle();
        string description = TaskData.GetDescription();
        ITask.TaskPriority priority = TaskData.GetPriority();

        ITask task = Factory.CreateTask(title, description, priority);

        _column.AddTask(task);
    }

    public void RemoveTask()
    {
        Guid? id_task = BoardData.GetId("Enter the task id");

        _column.RemoveTask(id_task);
    }

    public void Print()
    {
        Console.WriteLine("Title: " + _column.Title);
        Console.WriteLine("id: " + _column.Id);
        for (int tasksCounter = 0; tasksCounter < _column.Tasks.Count; ++tasksCounter)
        {
            ITask task = _column.Tasks[tasksCounter];
            Console.WriteLine("  " +  task.Title + " [" + task.Priority + "]");
            Console.WriteLine("  id: " + task.Id);
            Console.WriteLine("  -   " + task.Description);
        }
    }
}
