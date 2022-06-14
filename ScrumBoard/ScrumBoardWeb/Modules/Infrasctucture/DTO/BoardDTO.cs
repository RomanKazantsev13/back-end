namespace ScrumBoardWeb.Modules.Infrasctucture.DTO;

public class BoardDTO
{
    public string Id { get; }
    public string Title { get; }
    public IEnumerable<ColumnDTO> Columns { get; }

    public BoardDTO(string id, string title, IEnumerable<ColumnDTO> columns)
    {
        Id = id;
        Title = title;
        Columns = columns;
    }
}
