namespace ScrumBoardWeb.Modules.App.Exception;

class BoardNotFoundException : System.Exception
{
    public BoardNotFoundException()
        : base("Board not found")
    {
    }
}
