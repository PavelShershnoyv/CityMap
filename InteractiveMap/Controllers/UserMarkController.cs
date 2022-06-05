using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkService;
using InteractiveMap.Application.MarkService.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/user-marks")]
[Authorize]
public class UserMarkController : ApiControllerBase
{
    private readonly IUserMarkService _markService;

    public UserMarkController(IUserMarkService markService)
    {
        _markService = markService ?? throw new ArgumentNullException(nameof(markService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MarkBaseDto>>> GetAll([FromQuery] int layerId)
    {
        var marks = await _markService.GetMarksAsync(UserId, layerId);

        return Ok(marks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MarkDto>> GetById(int id)
    {
        var mark = await _markService.GetMarkAsync(UserId, id);

        return Ok(mark);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] MarkRequest request)
    {
        var id = await _markService.CreateMarkAsync(UserId, request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MarkRequest request)
    {
        await _markService.UpdateMarkAsync(UserId, id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _markService.DeleteMarkAsync(UserId, id);

        return NoContent();
    }
}
