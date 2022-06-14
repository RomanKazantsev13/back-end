namespace ScrumBoardWeb.Modules.Infrasctucture.Entity;

using System.ComponentModel.DataAnnotations;

public class Task
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }

    public virtual Column Column { get; set; }
}
