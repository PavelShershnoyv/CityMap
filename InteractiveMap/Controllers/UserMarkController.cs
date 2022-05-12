using InteractiveMap.Application.MarkService;
using InteractiveMap.Application.MarkService.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/user-marks")]
[Authorize]
public class UserMarkController : ApiController
{
    private readonly IUserMarkService _markService;

    public UserMarkController(IUserMarkService markService)
    {
        _markService = markService ?? throw new ArgumentNullException(nameof(markService));
    }

    [HttpGet]
    public async Task<ActionResult<MarkListDto>> GetAll([FromQuery] int layerId)
    {
        var marks = await _markService.GetMarksAsync(CurrentUserService.UserId, layerId);

        return Ok(marks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MarkDto>> Get(int id)
    {
        var mark = await _markService.GetMarkAsync(CurrentUserService.UserId, id);

        return Ok(mark);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<int>> Create(MarkRequest request)
    {
        var id = await _markService.CreateMarkAsync(CurrentUserService.UserId, request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MarkRequest request)
    {
        await _markService.UpdateMarkAsync(CurrentUserService.UserId, id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _markService.DeleteMarkAsync(CurrentUserService.UserId, id);

        return NoContent();
    }
}
