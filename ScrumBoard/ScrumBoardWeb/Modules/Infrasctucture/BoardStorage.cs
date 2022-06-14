namespace ScrumBoardWeb.Modules.Infrasctucture;

using ScrumBoardWeb.Modules.Infrasctucture.Config;
using ScrumBoardWeb.Modules.App;
using ScrumBoard;
using Microsoft.EntityFrameworkCore;

public class BoardStorage : IBoardStorage
{
    private ScrumBoardDbContext _context;

    public BoardStorage(ScrumBoardDbContext context)
    {
        _context = context;
    }

    public IBoard? GetBoard(Guid id_board)
    {
        Entity.Board? boardEntity = _context.Boards
            .Include(b => b.Columns)
            .ThenInclude(c => c.Tasks)
            .FirstOrDefault(b => b.Id == id_board);

        if (boardEntity != null)
        {
            return CreateBoardFromBoardEntity(boardEntity);
        }

        return null;
    }
    public IBoard? GetBoardByColumnId(Guid id_column)
    {

        Entity.Board? boardEntity = _context.Boards
            .Include(b => b.Columns)
            .ThenInclude(c => c.Tasks)
            .FirstOrDefault(b => b.Columns.Any(c => c.Id == id_column));

        if (boardEntity != null)
        {
            return CreateBoardFromBoardEntity(boardEntity);
        }

        return null;
    }
    public IBoard? GetBoardByTaskId(Guid id_task)
    {

        Entity.Board? boardEntity = _context.Boards
            .Include(b => b.Columns)
            .ThenInclude(c => c.Tasks)
            .FirstOrDefault(b => b.Columns.Any(c => c.Tasks.Any(t => t.Id == id_task)));

        if (boardEntity != null)
        {
            return CreateBoardFromBoardEntity(boardEntity);
        }

        return null;
    }
    public void RemoveBoard(Guid id_board)
    {
        Entity.Board? board = _context.Boards.Find(id_board);

        if (board != null)
        {
            _context.Boards.Remove(board);
            _context.SaveChanges();
        }
    }
    public void Store(IBoard board)
    {
        DeleteBoardFromContext(board);
        Entity.Board boardEntity = CreateBoardEntity(board);
        AddBoardEntityToContext(boardEntity);
    }

    private void DeleteBoardFromContext(IBoard board)
    {
        Entity.Board? boardEntity = _context.Boards
            .Include(b => b.Columns)
            .ThenInclude(c => c.Tasks)
            .FirstOrDefault(b => b.Id == board.Id);

        if (boardEntity != null)
        {
            _context.Boards.Remove(boardEntity);
            _context.SaveChanges();
        }
    }

    private Entity.Board CreateBoardEntity(IBoard board)
    {
        Entity.Board boardEntity = new();
        boardEntity.Id = board.Id;
        boardEntity.Title = board.Title;
        boardEntity.Columns = CreateColumnsEntity(board.Columns);

        return boardEntity;
    }

    private List<Entity.Column> CreateColumnsEntity(List<IColumn> columns)
    {
        List<Entity.Column> columnsEntity = new();

        foreach (IColumn column in columns)
        {
            Entity.Column columnEntity = new();

            columnEntity.Id = column.Id;
            columnEntity.Title = column.Title;
            columnEntity.Tasks = CreateTasksEntity(column.Tasks);
        }

        return columnsEntity;
    }

    private List<Entity.Task> CreateTasksEntity(List<ITask> tasks)
    {
        List<Entity.Task> tasksEntity = new();

        foreach (ITask task in tasks)
        {
            Entity.Task taskEntity = new();

            taskEntity.Id = task.Id;
            taskEntity.Title = task.Title;
            taskEntity.Description = task.Description;
            taskEntity.Priority = (int)task.Priority;

            tasksEntity.Add(taskEntity);
        }

        return tasksEntity;
    }

    private void AddBoardEntityToContext(Entity.Board boardEntity)
    {
        _context.Boards.Add(boardEntity);
        _context.SaveChanges();
    }

    private IBoard CreateBoardFromBoardEntity(Entity.Board boardEntity)
    {
        IBoard board = Factory.CreateBoard(boardEntity.Title);

        foreach (Entity.Column columnEntity in boardEntity.Columns)
        {
            IColumn column = Factory.CreateColumn(columnEntity.Title);

            foreach (Entity.Task taskEntity in columnEntity.Tasks)
            {
                ITask task = Factory.CreateTask(taskEntity.Title, taskEntity.Description, (ITask.TaskPriority)taskEntity.Priority);
                column.Tasks.Add(task);
            }

            board.Columns.Add(column);
        }

        return board;
    }
}
