namespace ScrumBoardWeb.Modules.Infrasctucture.DTO;

public class ColumnDTO
{
    public string Id { get; }
    public string Title { get; }
    public IEnumerable<TaskDTO> Tasks { get; }

    public ColumnDTO(string id, string title, IEnumerable<TaskDTO> tasks)
    {
        Id = id;
        Title = title;
        Tasks = tasks;
    }
}
