namespace ScrumBoardWeb.Modules.App;

using ScrumBoard;

public interface IBoardStorage
{
    public IBoard? GetBoard(Guid id_board);
    public IBoard? GetBoardByColumnId(Guid id_column);
    public IBoard? GetBoardByTaskId(Guid id_task);

    public void RemoveBoard(Guid id_board);
    public void Store(IBoard board);
}
