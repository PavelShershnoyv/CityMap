using InteractiveMap.Application.MarkService;
using InteractiveMap.Application.MarkService.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/marks")]
public class MarkController : ApiControllerBase
{
    private readonly IPublicMarkService _markService;

    public MarkController(IPublicMarkService markService)
    {
        _markService = markService ?? throw new ArgumentNullException(nameof(markService));
    }

    [HttpGet]
    public async Task<ActionResult<MarkListDto>> GetAll([FromQuery] int layerId)
    {
        var marks = await _markService.GetMarksAsync(layerId);

        return Ok(marks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MarkDto>> Get(int id)
    {
        var mark = await _markService.GetMarkAsync(id);

        return Ok(mark);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<int>> Create(MarkRequest request)
    {
        var id = await _markService.CreateMarkAsync(request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, MarkRequest request)
    {
        await _markService.UpdateMarkAsync(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _markService.DeleteMarkAsync(id);

        return NoContent();
    }
}
