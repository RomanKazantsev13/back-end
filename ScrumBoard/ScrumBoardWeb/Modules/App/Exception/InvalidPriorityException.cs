namespace ScrumBoardWeb.Modules.App.Exception;

class InvalidPriorityException : System.Exception
{
    public InvalidPriorityException()
        : base("Invalid priority")
    {
    }
}
