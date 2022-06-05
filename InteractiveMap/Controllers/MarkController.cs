using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkService;
using InteractiveMap.Application.MarkService.Types;
using InteractiveMap.Infrastructure.Identity.Defaults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/marks")]
public class MarkController : ApiControllerBase
{
    private readonly IMarkService _markService;

    public MarkController(IMarkService markService)
    {
        _markService = markService ?? throw new ArgumentNullException(nameof(markService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MarkBaseDto>>> GetAll([FromQuery] int layerId)
    {
        var marks = await _markService.GetMarksAsync(layerId);

        return Ok(marks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MarkDto>> GetById(int id)
    {
        var mark = await _markService.GetMarkAsync(id);

        return Ok(mark);
    }

    [HttpPost]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<ActionResult<int>> Create(MarkRequest request)
    {
        var id = await _markService.CreateMarkAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = id });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<IActionResult> Update(int id, MarkRequest request)
    {
        await _markService.UpdateMarkAsync(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        await _markService.DeleteMarkAsync(id);

        return NoContent();
    }
}
