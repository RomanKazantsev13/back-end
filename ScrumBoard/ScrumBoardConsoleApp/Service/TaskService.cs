namespace ScrumBoardConsoleApp;

using ScrumBoard;

public class TaskService
{
    private ITask _task;

    public TaskService(ITask task)
    {
        _task = task;
    }

    public void ChangeTitle()
    {
        _task.Title = ScrumBoardService.GetTitle();
    }

    public void ChangeDescription()
    {
        _task.Description = ScrumBoardService.GetDescription();
    }

    public void ChangePriority()
    {
        _task.Priority = ScrumBoardService.GetPriority();
    }

    public void Print()
    {
         Console.WriteLine("Title: " + _task.Title + " [" + _task.Priority + "]");
         Console.WriteLine("  -   " + _task.Description);
         Console.WriteLine("  id: " + _task.Id);
    }
}
