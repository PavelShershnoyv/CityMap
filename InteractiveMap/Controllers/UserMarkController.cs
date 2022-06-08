using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.Services.MarkService;
using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;
using InteractiveMap.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/user-marks")]
[Authorize]
public class UserMarkController : ApiControllerBase
{
    private readonly IBaseMarkService<UserMark> _markService;

    public UserMarkController(IBaseMarkService<UserMark> markService)
    {
        _markService = markService ?? throw new ArgumentNullException(nameof(markService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MarkBaseDto>>> GetAll([FromQuery] LayerType layerType)
    {
        var marks = await _markService.GetAllAsync(layerType);

        return Ok(marks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MarkDto>> GetById(int id)
    {
        var mark = await _markService.GetByIdAsync(id);

        return Ok(mark);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] MarkRequest request)
    {
        var id = await _markService.CreateAsync(request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MarkRequest request)
    {
        await _markService.UpdateAsync(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _markService.DeleteAsync(id);

        return NoContent();
    }
}
