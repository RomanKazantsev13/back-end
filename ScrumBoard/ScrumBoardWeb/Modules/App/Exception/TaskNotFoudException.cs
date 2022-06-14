namespace ScrumBoardWeb.Modules.App.Exception;

class TaskNotFoundException : System.Exception
{
    public TaskNotFoundException()
        : base("Task not found")
    {

    }
}
