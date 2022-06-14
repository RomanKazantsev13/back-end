namespace ScrumBoardWeb.Modules.Infrasctucture;

using Microsoft.EntityFrameworkCore;
using ScrumBoardWeb.Modules.Infrasctucture.Config;
using ScrumBoardWeb.Modules.Infrasctucture.DTO;
using ScrumBoardWeb.Modules.Infrasctucture.Entity;

public class DTOService : IDTOService
{
    private ScrumBoardDbContext _context;

    public DTOService(ScrumBoardDbContext context)
    {
        _context = context;
    }

    public IEnumerable<BoardDTO> GetBoardList()
    {
        List<Board> boards = _context.Boards
            .Include(b => b.Columns)
            .ThenInclude(c => c.Tasks)
            .ToList();

        List<BoardDTO> newBoards = new();
        foreach (Board board in boards)
        {
            List<ColumnDTO> columns = new();
            foreach (Column column in board.Columns)
            {
                List<TaskDTO> tasks = new();
                foreach (Task task in column.Tasks)
                {
                    TaskDTO newTask = new TaskDTO(task.Id.ToString(), task.Title, task.Description, task.Priority.ToString());
                    tasks.Add(newTask);
                }

                ColumnDTO newColumn = new ColumnDTO(column.Id.ToString(), column.Title, tasks);
                columns.Add(newColumn);
            }

            BoardDTO newBoard = new BoardDTO(board.Id.ToString(), board.Title, columns);
        }

        return newBoards;
    }
}
