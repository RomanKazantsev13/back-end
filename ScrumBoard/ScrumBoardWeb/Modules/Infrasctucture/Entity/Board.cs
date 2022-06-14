namespace ScrumBoardWeb.Modules.Infrasctucture.Entity;

using System.ComponentModel.DataAnnotations;

public class Board
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; }
    public ICollection<Column> Columns { get; set; }
}
