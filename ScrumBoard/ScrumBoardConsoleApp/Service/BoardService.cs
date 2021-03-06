namespace ScrumBoardConsoleApp;

using ScrumBoard;

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
                IColumn  column = Factory.CreateColumn(title);
                _board.AddColumn(column);
                break;
            }

            Console.WriteLine(" > Invalid title value");
        }
    }

    public void AddTask()
    {
        string title = ScrumBoardService.GetTitle();
        string description = ScrumBoardService.GetDescription();
        ITask.TaskPriority priority = ScrumBoardService.GetPriority();

        ITask task = Factory.CreateTask(title, description, priority);
        _board.AddTask(task);
    }

    public void MoveTask()
    {
        Guid? id_task = ScrumBoardService.GetId("Enter the task id");
        Guid? id_column = ScrumBoardService.GetId("Enter the column id");

        _board.MoveTask(id_column, id_task);
    }

    public void RemoveColumn()
    {
        Guid? id_column = ScrumBoardService.GetId("Enter the column id");

        _board.RemoveColumn(id_column);
    }

    public void RemoveTask()
    {
        Guid? id_task = ScrumBoardService.GetId("Enter the task id");

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

