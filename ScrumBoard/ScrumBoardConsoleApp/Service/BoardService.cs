namespace ScrumBoardConsoleApp;

using ScrumBoard;
using ScrumBoardConsoleApp.Data;

public class BoardService
{
    private IBoard _board;

    public BoardService(IBoard board)
    {
        _board = board;
    }

    public void AddColumn()
    {
        string? title = "";

        while (true)
        {
            Console.Write("Enter a new column title");
            title = Console.ReadLine();
            Console.WriteLine();

            if (title != "" && title != null)
            {
                _board.AddColumn(title);
                break;
            }

            Console.WriteLine(" > Invalid title value");
        }
    }

    public void AddTask()
    {
        string title = TaskData.GetTitle();
        string description = TaskData.GetDescription();
        ITask.TaskPriority priority = TaskData.GetPriority();

        _board.AddTask(title, description, priority);
    }

    public void MoveTask()
    {
        Guid? id_task = BoardData.GetId("Enter the task id");
        Guid? id_column = BoardData.GetId("Enter the column id");

        _board.MoveTask(id_column, id_task);
    }

    public void RemoveColumn()
    {
        Guid? id_column = BoardData.GetId("Enter the column id");

        _board.RemoveColumn(id_column);
    }

    public void RemoveTask()
    {
        Guid? id_task = BoardData.GetId("Enter the task id");

        _board.RemoveTask(id_task);
    }

    public void Print()
    {
        Console.WriteLine("=======================================================");
        Console.WriteLine("Board: " + _board.Title);
        Console.WriteLine("id: " + _board.Id);
        Console.WriteLine("=======================================================");

        for (int columnCounter = 0; columnCounter < _board.Columns.Count; ++columnCounter)
        {
            IColumn column = _board.Columns[columnCounter];
            Console.WriteLine(column.Title);
            Console.WriteLine("id: " + column.Id);
            for (int tasksCounter = 0; tasksCounter < column.Tasks.Count; ++tasksCounter)
            {
                ITask task = column.Tasks[tasksCounter];
                Console.WriteLine("  " + task.Title + " [" + task.Priority + "]");
                Console.WriteLine("  id: " + task.Id);
                Console.WriteLine("  -   " + task.Description);
            }
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}

