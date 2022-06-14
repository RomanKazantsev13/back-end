namespace ScrumBoardWeb.Modules.App;

using ScrumBoardWeb.Modules.Infrasctucture;
using ScrumBoard;

public class BoardService : IBoardService
{
    private IBoardStorage _boardStorage;

    public BoardService (IBoardStorage boardStorage)
    {
        _boardStorage = boardStorage;
    }

    public Guid AddTaskInColumn(Guid id_column, string title, string description, ITask.TaskPriority priority)
    {
        ITask task = Factory.CreateTask(title, description, priority);
        IBoard board = _boardStorage.GetBoardByTaskId(task.Id);
        board.AddTask(task);

        _boardStorage.Store(board);

        return task.Id;
    }
    public void RemoveTask(Guid id_task)
    {
        IBoard board = _boardStorage.GetBoardByTaskId(id_task);
        board.RemoveTask(id_task);

        _boardStorage.Store(board);
    }
    public Guid AddColumnInBoard(Guid id_board, string title)
    {
        IColumn column = Factory.CreateColumn(title);
        IBoard board = _boardStorage.GetBoard(id_board);
        board.AddColumn(column);

        _boardStorage.Store(board);

        return column.Id;
    }
    public void RemoveColumn(Guid id_column)
    {
        IBoard board = _boardStorage.GetBoardByColumnId(id_column);
        board.RemoveColumn(id_column);

        _boardStorage.Store(board);
    }
    public Guid AddBoard(string title)
    {
        IBoard board = Factory.CreateBoard(title);
        _boardStorage.Store(board);

        return board.Id;
    }
    public void RemoveBoard(Guid id_board)
    {
        _boardStorage.RemoveBoard(id_board);
    }
    public void ChangeTaskTitle(Guid id_task, string title)
    {
        IBoard board = _boardStorage.GetBoardByTaskId(id_task);
        ITask? task = board.GetTask(id_task);

        if (task != null)
        {
            task.Title = title;
            _boardStorage.Store(board);
        }
    }
    public void ChangeTaskDescription(Guid id_task, string description)
    {
        IBoard board = _boardStorage.GetBoardByTaskId(id_task);
        ITask? task = board.GetTask(id_task);


        if (task != null)
        {
            task.Description = description;
            _boardStorage.Store(board);
        }
    }
    public void ChangeTaskPriority(Guid id_task, ITask.TaskPriority priority)
    {
        IBoard board = _boardStorage.GetBoardByTaskId(id_task);
        ITask? task = board.GetTask(id_task);


        if (task != null)
        {
            task.Priority = priority;
            _boardStorage.Store(board);
        }
    }
    public void MoveTask(Guid id_task, Guid id_column)
    {
        IBoard board = _boardStorage.GetBoardByTaskId(id_task);
        board.MoveTask(id_column, id_task);

        _boardStorage.Store(board);
    }
}
