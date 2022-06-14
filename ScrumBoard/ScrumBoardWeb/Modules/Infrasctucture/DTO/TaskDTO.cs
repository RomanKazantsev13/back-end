namespace ScrumBoardWeb.Modules.Infrasctucture.DTO;

public class TaskDTO
{
    public string Id { get; }
    public string Title { get; }
    public string Description { get; }
    public string Priority { get; }

    public TaskDTO(string id, string title, string description, string priority)
    {
        Id = id;
        Title = title;
        Description = description;
        Priority = priority;
    }
}
