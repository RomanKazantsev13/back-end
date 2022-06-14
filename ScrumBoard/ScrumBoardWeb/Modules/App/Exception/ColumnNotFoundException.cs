namespace ScrumBoardWeb.Modules.App.Exception;

class ColumnNotFoundException : System.Exception
{
    public ColumnNotFoundException()
        : base("Column not found")
    {
    }
}
