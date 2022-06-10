using ScrumBoard;

enum Answer
{
    Yes,
    No
}

class Program
{
    static void Main(string[] args)
    {
        string? boardTitle = null;
        while (true)
        {
            Console.Write("Enter the name of the board: ");
            boardTitle = Console.ReadLine();
            if (!String.IsNullOrEmpty(boardTitle) && !String.IsNullOrWhiteSpace(boardTitle))
            {
                break;
            }
            Console.WriteLine(" > Invalid board name");
        }

        IBoard board = Factory.CreateBoard(boardTitle);

        string? command = "";
        ShowCommands();
        while (command != "...")
        {
            command = Console.ReadLine();
            if (!HandleCommand(board, command))
            {
                Console.WriteLine(" > Unknown command");
            }
            Console.WriteLine();
        }
    }

    static void ShowCommands()
    {
        Console.WriteLine();
        Console.WriteLine("Enter \"AddColumn\" to add a column");
        Console.WriteLine("Enter \"DeleteColumn\" to delete the column");
        Console.WriteLine("Enter \"AddTask\" to add a task");
        Console.WriteLine("Enter \"DeleteTask\" to delete the task");
        Console.WriteLine("Enter \"ChangeData\" to change the task data");
        Console.WriteLine("Enter \"MoveTask\" to move the task");
        Console.WriteLine("Enter \"PrintBoard\" to print the entire board");
        Console.WriteLine("Enter \"...\" to exit");
        Console.WriteLine();
    }

    static bool HandleCommand(IBoard board, string command)
    {
        switch (command)
        {
            case "AddColumn":
                AddColumn(board);
                return true;

            case "DeleteColumn":
                DeleteColumn(board);
                return true;

            case "AddTask":
                AddTask(board);
                return true;

            case "DeleteTask":
                DeleteTask(board);
                return true;

            case "ChangeData":
                ChangeData(board);
                return true;

            case "MoveTask":
                MoveTask(board);
                return true;

            case "PrintBoard":
                PrintBoard(board);
                return true;

            case "...":
                return true;

            default:
                return false; 
        }
    }

    static void AddColumn(IBoard board)
    {
        if (board.Columns.Count >= 10)
        {
            Console.WriteLine(" > The maximum number of columns has been reached");
            return;
        }

        Console.Write("Enter the column name: ");
        string? title = Console.ReadLine();

        board.AddColumn(title);
    }

    static void DeleteColumn(IBoard board)
    {
        int? columnIndex = GetColumnIndex(board.Columns.Count);
        if (columnIndex == null)
            return;
        IColumn column = board.Columns[columnIndex.Value];

        board.RemoveColumn(column.Id);
    }

    static void AddTask(IBoard board)
    {
        if (board.Columns.Count == 0)
        {
            Console.WriteLine(" > To add tasks, you need to add a column");
            return;
        }

        Console.Write("Enter the task name: ");
        string? title = Console.ReadLine();

        Console.Write("Enter the description: ");
        string? description = Console.ReadLine();

        ITask.TaskPriority priority = GetPriority();

        board.AddTask(title, description, priority);
    }

    static void DeleteTask(IBoard board)
    {
        int? columnIndex = GetColumnIndex(board.Columns.Count);
        if (columnIndex == null)
            return;
        IColumn column = board.Columns[columnIndex.Value];

        int? taskIndex = GetTaskIndex(column.Tasks.Count);
        if (taskIndex == null)
            return;
        ITask task = column.Tasks[taskIndex.Value];

        column.RemoveTask(task.Id);
    }

    static void ChangeData(IBoard board)
    {
        int? columnIndex = GetColumnIndex(board.Columns.Count);
        if (columnIndex == null)
            return;
        IColumn column = board.Columns[columnIndex.Value];

        int? taskIndex = GetTaskIndex(column.Tasks.Count);
        if (taskIndex == null)
            return;
        ITask task = column.Tasks[taskIndex.Value];
        Console.WriteLine();

        Console.WriteLine("Do you want to change title?");
        if (IsNeedToChange())
        {
            Console.Write("Enter the task name: ");
            string? title = Console.ReadLine();

            task.Title = title;
        }

        Console.WriteLine("Do you want to change description?");
        if (IsNeedToChange())
        {
            Console.Write("Enter the description: ");
            string? description = Console.ReadLine();

            task.Description = description;
        }

        Console.WriteLine("Do you want to change priority?");
        if (IsNeedToChange())
        {
            ITask.TaskPriority priority = GetPriority();

            task.Priority = priority;
        }
    }

    static void MoveTask(IBoard board)
    {
        Console.WriteLine("From: ");
        Console.Write("   ");
        int? columnIndexFrom = GetColumnIndex(board.Columns.Count);
        if (columnIndexFrom == null)
            return;
        IColumn columnFrom = board.Columns[columnIndexFrom.Value];

        Console.Write("   ");
        int? taskIndex = GetTaskIndex(columnFrom.Tasks.Count);
        if (taskIndex == null)
            return;
        ITask task = columnFrom.Tasks[taskIndex.Value];

        Console.WriteLine("To: ");
        Console.Write("   ");
        int? columnIndexTo = GetColumnIndex(board.Columns.Count);
        if (columnIndexTo == null)
            return;
        IColumn columnTo = board.Columns[columnIndexTo.Value];

        board.MoveTask(columnTo.Id, task.Id);
    }

    static void PrintBoard(IBoard board)
    {
        Console.WriteLine("=======================================================");
        Console.WriteLine("Board: " + board.Title);
        Console.WriteLine("=======================================================");

        for (int columnCounter = 0; columnCounter < board.Columns.Count; ++columnCounter)
        {
            IColumn column = board.Columns[columnCounter];
            Console.WriteLine("(Column " + (columnCounter + 1) + ") " + column.Title);
            for (int tasksCounter = 0; tasksCounter < column.Tasks.Count; ++tasksCounter)
            {
                ITask task = column.Tasks[tasksCounter];
                Console.WriteLine("    <Task " + (tasksCounter + 1) + "> " + task.Title + " [" + task.Priority + "]");
                Console.WriteLine("       - " + task.Description);
            }
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    static bool IsNeedToChange()
    {
        string? str;
        Answer answer;
        while (true)
        {
            Console.Write("Enter Yes or No: ");
            str = Console.ReadLine();
            if (Enum.TryParse(str, out answer))
            {
                break;
            }
            Console.WriteLine(" > Invalid answer");
        }

        return answer == Answer.Yes;
    }

    static int? GetColumnIndex(int numberOfColumns)
    {
        Console.Write("Enter the column number: ");
        int columnNumber;
        Int32.TryParse(Console.ReadLine(), out columnNumber);

        if (columnNumber > numberOfColumns || columnNumber <= 0)
        {
            Console.WriteLine(" > This column does not exist");
            return null;
        }

        return columnNumber - 1;
    }

    static int? GetTaskIndex(int numberOfTask)
    {
        Console.Write("Enter the task number: ");
        int columnTask;
        Int32.TryParse(Console.ReadLine(), out columnTask);

        if (columnTask > numberOfTask || columnTask <= 0)
        {
            Console.WriteLine(" > This task does not exist");
            return null;
        }

        return columnTask - 1;
    }

    static ITask.TaskPriority GetPriority()
    {
        string? str;
        ITask.TaskPriority priority;
        while (true)
        {
            Console.Write("Enter the priority (Lowest, BelowNormal, Normal, AboveNormal, Highest): ");
            str = Console.ReadLine();
            if (Enum.TryParse(str, out priority))
            {
                break;
            }
            Console.WriteLine(" > Invalid priority value");
        }

        return priority;
    }
}
