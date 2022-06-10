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
        if (board.m_columns.Count >= 10)
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
        int? columnIndex = GetColumnIndex(board.m_columns.Count);
        if (columnIndex == null)
            return;
        IColumn column = board.m_columns[columnIndex.Value];

        board.RemoveColumn(column.m_id);
    }

    static void AddTask(IBoard board)
    {
        if (board.m_columns.Count == 0)
        {
            Console.WriteLine(" > To add tasks, you need to add a column");
            return;
        }

        Console.Write("Enter the task name: ");
        string? title = Console.ReadLine();

        Console.Write("Enter the description: ");
        string? description = Console.ReadLine();

        ITask.Priority priority = GetPriority();

        board.AddTask(title, description, priority);
    }

    static void DeleteTask(IBoard board)
    {
        int? columnIndex = GetColumnIndex(board.m_columns.Count);
        if (columnIndex == null)
            return;
        IColumn column = board.m_columns[columnIndex.Value];

        int? taskIndex = GetTaskIndex(column.m_tasks.Count);
        if (taskIndex == null)
            return;
        ITask task = column.m_tasks[taskIndex.Value];

        column.RemoveTask(task.m_id);
    }

    static void ChangeData(IBoard board)
    {
        int? columnIndex = GetColumnIndex(board.m_columns.Count);
        if (columnIndex == null)
            return;
        IColumn column = board.m_columns[columnIndex.Value];

        int? taskIndex = GetTaskIndex(column.m_tasks.Count);
        if (taskIndex == null)
            return;
        ITask task = column.m_tasks[taskIndex.Value];
        Console.WriteLine();

        Console.WriteLine("Do you want to change title?");
        if (IsNeedToChange())
        {
            Console.Write("Enter the task name: ");
            string? title = Console.ReadLine();

            task.m_title = title;
        }

        Console.WriteLine("Do you want to change description?");
        if (IsNeedToChange())
        {
            Console.Write("Enter the description: ");
            string? description = Console.ReadLine();

            task.m_description = description;
        }

        Console.WriteLine("Do you want to change priority?");
        if (IsNeedToChange())
        {
            ITask.Priority priority = GetPriority();

            task.m_priority = priority;
        }
    }

    static void MoveTask(IBoard board)
    {
        Console.WriteLine("From: ");
        Console.Write("   ");
        int? columnIndexFrom = GetColumnIndex(board.m_columns.Count);
        if (columnIndexFrom == null)
            return;
        IColumn columnFrom = board.m_columns[columnIndexFrom.Value];

        Console.Write("   ");
        int? taskIndex = GetTaskIndex(columnFrom.m_tasks.Count);
        if (taskIndex == null)
            return;
        ITask task = columnFrom.m_tasks[taskIndex.Value];

        Console.WriteLine("To: ");
        Console.Write("   ");
        int? columnIndexTo = GetColumnIndex(board.m_columns.Count);
        if (columnIndexTo == null)
            return;
        IColumn columnTo = board.m_columns[columnIndexTo.Value];

        board.MoveTask(columnTo.m_id, task.m_id);
    }

    static void PrintBoard(IBoard board)
    {
        Console.WriteLine("=======================================================");
        Console.WriteLine("Board: " + board.m_title);
        Console.WriteLine("=======================================================");

        for (int columnCounter = 0; columnCounter < board.m_columns.Count; ++columnCounter)
        {
            IColumn column = board.m_columns[columnCounter];
            Console.WriteLine("(Column " + (columnCounter + 1) + ") " + column.m_title);
            for (int tasksCounter = 0; tasksCounter < column.m_tasks.Count; ++tasksCounter)
            {
                ITask task = column.m_tasks[tasksCounter];
                Console.WriteLine("    <Task " + (tasksCounter + 1) + "> " + task.m_title + " [" + task.m_priority + "]");
                Console.WriteLine("       - " + task.m_description);
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

    static ITask.Priority GetPriority()
    {
        string? str;
        ITask.Priority priority;
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
