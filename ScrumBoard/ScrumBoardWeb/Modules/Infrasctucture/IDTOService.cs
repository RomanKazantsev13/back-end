namespace ScrumBoardWeb.Modules.Infrasctucture;

using ScrumBoardWeb.Modules.Infrasctucture.DTO;

public interface IDTOService
{
    public IEnumerable<BoardDTO> GetBoardList();
}
