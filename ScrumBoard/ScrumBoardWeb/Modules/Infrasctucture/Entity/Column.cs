namespace ScrumBoardWeb.Modules.Infrasctucture.Entity;

using System.ComponentModel.DataAnnotations;

public class Column
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; }
    public ICollection<Task> Tasks { get; set; }

    public virtual Board Board { get; set; }
}
