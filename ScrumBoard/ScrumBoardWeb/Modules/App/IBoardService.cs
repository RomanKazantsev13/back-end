namespace ScrumBoardWeb.Modules.App;

using ScrumBoard;

public interface IBoardService
{
    public Guid AddTaskInColumn(Guid id_column, string title, string description, ITask.TaskPriority priority);
    public void RemoveTask(Guid id_task);
    public Guid AddColumnInBoard(Guid id_board, string title);
    public void RemoveColumn(Guid id_column);
    public Guid AddBoard(string title);
    public void RemoveBoard(Guid id_board);
    public void ChangeTaskTitle(Guid id_task, string title);
    public void ChangeTaskDescription(Guid id_task, string description);
    public void ChangeTaskPriority(Guid id_task, ITask.TaskPriority priority);
    public void MoveTask(Guid id_task, Guid id_column);
}
