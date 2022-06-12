namespace ScrumBoardConsoleApp;

using ScrumBoard;
using ScrumBoardConsoleApp.Data;

public class TaskService
{
    private ITask _task;

    public TaskService(ITask task)
    {
        _task = task;
    }

    public void ChangeTitle()
    {
        _task.Title = TaskData.GetTitle();
    }

    public void ChangeDescription()
    {
        _task.Description = TaskData.GetDescription();
    }

    public void ChangePriority()
    {
        _task.Priority = TaskData.GetPriority();
    }

    public void Print()
    {
         Console.WriteLine("Title: " + _task.Title + " [" + _task.Priority + "]");
         Console.WriteLine("  -   " + _task.Description);
         Console.WriteLine("  id: " + _task.Id);
    }
}
