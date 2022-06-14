namespace ScrumBoardWeb.Controllers;

using Microsoft.AspNetCore.Mvc;
using ScrumBoardWeb.Modules.App;
using ScrumBoardWeb.Modules.Infrasctucture;
using ScrumBoardWeb.Modules.Infrasctucture.DTO;

[ApiController]
[Route("api/")]
public class ScrumBoardController : ControllerBase
{
    private IBoardService _boardService;
    private IDTOService _dtoService;

    public ScrumBoardController(IBoardService boardService, IDTOService dtoService)
    {
        _boardService = boardService;
        _dtoService = dtoService;
    }

    //GET api/boards
    [HttpGet("boards")]
    public IActionResult GetBoards()
    {
        IEnumerable<BoardDTO> boards = _dtoService.GetBoardList();

        return Ok(boards);
    }
}
