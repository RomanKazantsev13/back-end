namespace ScrumBoardConsoleApp;

using ScrumBoard;

enum State
{
    WorkWithBoards,
    WorkWithBoard,
    WorkWithColumn,
    WorkWithTask
}

class Controller
{
    private static IBoard? _board;
    private static IColumn? _column;
    private static ITask? _task;
    private static State _state = State.WorkWithBoards;
    public static List<IBoard> boards = new List<IBoard>();

    public static void ShowCommands()
    {
        Console.WriteLine("---Help---");
        if (_state == State.WorkWithBoards)
        {
            ShowDefaultCommands();
        }
        if (_state == State.WorkWithBoard)
        {
            ShowCommandsForBoard();
        }
        if (_state == State.WorkWithColumn)
        {
            ShowCommandsForColumn();
        }
        if (_state == State.WorkWithTask)
        {
            ShowCommandsForTask();
        }
        Console.WriteLine();
    }

    static void ShowCommandsForBoard()
    {
        Console.WriteLine("----------------");
        Console.WriteLine("| AddColumn    |");
        Console.WriteLine("| AddTask      |");
        Console.WriteLine("| RemoveColumn |");
        Console.WriteLine("| RemoveTask   |");
        Console.WriteLine("| MoveTask     |");
        Console.WriteLine("| Print        |");
        Console.WriteLine("| Default      |");
        Console.WriteLine("| Use Board    |");
        Console.WriteLine("| Use Column   |");
        Console.WriteLine("| Use Task     |");
        Console.WriteLine("----------------");
    }
    static void ShowCommandsForColumn()
    {
        Console.WriteLine("----------------");
        Console.WriteLine("| AddTask      |");
        Console.WriteLine("| RemoveTask   |");
        Console.WriteLine("| Print        |");
        Console.WriteLine("| Default      |");
        Console.WriteLine("| Use Board    |");
        Console.WriteLine("| Use Column   |");
        Console.WriteLine("| Use Task     |");
        Console.WriteLine("----------------");
    }
    static void ShowCommandsForTask()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("| ChangeTitle       |");
        Console.WriteLine("| ChangeDescription |");
        Console.WriteLine("| ChangePriority    |");
        Console.WriteLine("| Print             |");
        Console.WriteLine("| Default           |");
        Console.WriteLine("| Use Board         |");
        Console.WriteLine("| Use Column        |");
        Console.WriteLine("| Use Task          |");
        Console.WriteLine("---------------------");
    }
    static void ShowDefaultCommands()
    {
        Console.WriteLine("----------------");
        Console.WriteLine("| AddBoard     |");
        Console.WriteLine("| RemoveBoard  |");
        Console.WriteLine("| PrintBoards  |");
        Console.WriteLine("| Use Board    |");
        Console.WriteLine("| Use Column   |");
        Console.WriteLine("| Use Task     |");
        Console.WriteLine("----------------");
    }

    public static bool HandleCommand(string? command)
    {
        if (_state == State.WorkWithBoards)
        {
            return HandleBoardsCommand(command);
        }
        if (_state == State.WorkWithBoard)
        {
            return HandleBoardCommand(command);
        }
        if (_state == State.WorkWithColumn)
        {
            return HandleColumnCommand(command);
        }
        if (_state == State.WorkWithTask)
        {
            return HandleTaskCommand(command);
        }

        return false;
    }

    static bool HandleBoardsCommand(string? command)
    {
        switch (command)
        {
            case "AddBoard":
                AddBoard();
                return true;

            case "RemoveBoard":
                RemoveBoard();
                return true;

            case "PrintBoards":
                PrintBoards();
                return true;

            case "Use Board":
                Guid? id_board = ScrumBoardService.GetId("Enter the board id");
                _board = GetBoard(id_board);

                if (_board != null)
                {
                    _state = State.WorkWithBoard;
                }

                return true;

            case "Use Column":
                _state = State.WorkWithColumn;
                Guid? id_column = ScrumBoardService.GetId("Enter the column id");
                _column = GetColumn(id_column);

                if (_column != null)
                {
                    _state = State.WorkWithColumn;
                }

                return true;

            case "Use Task":
                _state = State.WorkWithTask;
                Guid? id_task = ScrumBoardService.GetId("Enter the task id");
                _task = GetTask(id_task);

                if (_task != null)
                {
                    _state = State.WorkWithTask;
                }

                return true;

            case "...":
                return true;

            default:
                return false;
        }
    }

    static bool HandleBoardCommand(string? command)
    {
        BoardService board = new BoardService(_board);

        switch (command)
        {
            case "AddColumn":
                board.AddColumn();
                return true;

            case "AddTask":
                board.AddTask();
                return true;

            case "RemoveColumn":
                board.RemoveColumn();
                return true;

            case "RemoveTask":
                board.RemoveTask();
                return true;

            case "MoveTask":
                board.MoveTask();
                return true;

            case "Print":
                board.Print();
                return true;

            case "Use Board":
                Guid? id_board = ScrumBoardService.GetId("Enter the board id");
                _board = GetBoard(id_board);

                if (_board != null)
                {
                    _state = State.WorkWithBoard;
                }

                return true;

            case "Use Column":
                _state = State.WorkWithColumn;
                Guid? id_column = ScrumBoardService.GetId("Enter the column id");
                _column = GetColumn(id_column);

                if (_column != null)
                {
                    _state = State.WorkWithColumn;
                }

                return true;

            case "Use Task":
                _state = State.WorkWithTask;
                Guid? id_task = ScrumBoardService.GetId("Enter the task id");
                _task = GetTask(id_task);

                if (_task != null)
                {
                    _state = State.WorkWithTask;
                }

                return true;

            case "Default":
                _state = State.WorkWithBoards;
                return true;

            case "...":
                return true;

            default:
                return false;
        }
    }

    static bool HandleColumnCommand(string? command)
    {
        ColumnService column = new ColumnService(_column);

        switch (command)
        {
            case "AddTask":
                column.AddTask();
                return true;

            case "RemoveTask":
                column.RemoveTask();
                return true;

            case "Print":
                column.Print();
                return true;

            case "Default":
                _state = State.WorkWithBoards;
                return true;

            case "Use Board":
                Guid? id_board = ScrumBoardService.GetId("Enter the board id");
                _board = GetBoard(id_board);

                if (_board != null)
                {
                    _state = State.WorkWithBoard;
                }

                return true;

            case "Use Column":
                _state = State.WorkWithColumn;
                Guid? id_column = ScrumBoardService.GetId("Enter the column id");
                _column = GetColumn(id_column);

                if (_column != null)
                {
                    _state = State.WorkWithColumn;
                }

                return true;

            case "Use Task":
                _state = State.WorkWithTask;
                Guid? id_task = ScrumBoardService.GetId("Enter the task id");
                _task = GetTask(id_task);

                if (_task != null)
                {
                    _state = State.WorkWithTask;
                }

                return true;

            case "...":
                return true;

            default:
                return false;
        }
    }

    static bool HandleTaskCommand(string? command)
    {
        TaskService task = new TaskService(_task);

        switch (command)
        {
            case "ChangeTitle":
                task.ChangeTitle();
                return true;

            case "ChangeDescription":
                task.ChangeDescription();
                return true;

            case "ChangePriority":
                task.ChangePriority();
                return true;

            case "Print":
                task.Print();
                return true;

            case "Default":
                _state = State.WorkWithBoards;
                return true;

            case "Use Board":
                Guid? id_board = ScrumBoardService.GetId("Enter the board id");
                _board = GetBoard(id_board);

                if (_board != null)
                {
                    _state = State.WorkWithBoard;
                }

                return true;

            case "Use Column":
                _state = State.WorkWithColumn;
                Guid? id_column = ScrumBoardService.GetId("Enter the column id");
                _column = GetColumn(id_column);

                if (_column != null)
                {
                    _state = State.WorkWithColumn;
                }

                return true;

            case "Use Task":
                _state = State.WorkWithTask;
                Guid? id_task = ScrumBoardService.GetId("Enter the task id");
                _task = GetTask(id_task);

                if (_task != null)
                {
                    _state = State.WorkWithTask;
                }

                return true;

            case "...":
                return true;

            default:
                return false;
        }
    }

    static IBoard? GetBoard(Guid? id_board)
    {
        foreach (IBoard board in boards)
        {
            if (board.Id == id_board)
            {
                return board;
            }
        }

        return null;
    }

    static IColumn? GetColumn(Guid? id_column)
    {
        foreach (IBoard board in boards)
        {
            foreach (IColumn column in board.Columns)
            {
                if (column.Id == id_column)
                {
                    return column;
                }
            }
        }

        return null;
    }

    static ITask? GetTask(Guid? id_task)
    {
        foreach (IBoard board in boards)
        {
            foreach (IColumn column in board.Columns)
            {
                foreach (ITask task in column.Tasks)
                {
                    if (task.Id == id_task)
                    {
                        return task;
                    }
                }
            }
        }

        return null;
    }

    static void AddBoard()
    {
        string? title = "";

        while (true)
        {
            Console.Write("Enter a new column title: ");
            title = Console.ReadLine();
            Console.WriteLine();

            if (title != "" && title != null)
            {
                IBoard board = Factory.CreateBoard(title);
                boards.Add(board);
                break;
            }

            Console.WriteLine(" > Invalid title value");
        }
    }

    static void RemoveBoard()
    {
        Guid? id_board = ScrumBoardService.GetId("Enter the board id");

        foreach (IBoard board in boards)
        {
            if (board.Id == id_board)
            {
                boards.Remove(board);
                return;
            }
        }
    }

    static void PrintBoards()
    {
        foreach (IBoard board in boards)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("Board: " + board.Title);
            Console.WriteLine("id: " + board.Id);
            Console.WriteLine("=======================================================");

            for (int columnCounter = 0; columnCounter < board.Columns.Count; ++columnCounter)
            {
                IColumn column = board.Columns[columnCounter];
                Console.WriteLine(column.Title);
                Console.WriteLine("id: " + column.Id);
                for (int tasksCounter = 0; tasksCounter < column.Tasks.Count; ++tasksCounter)
                {
                    ITask task = column.Tasks[tasksCounter];
                    Console.WriteLine("  > " + task.Title + " [" + task.Priority + "]");
                    Console.WriteLine("    id: " + task.Id);
                    Console.WriteLine("    - " + task.Description);
                }
                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}

