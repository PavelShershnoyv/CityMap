using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.Services.MarkService;
using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;
using InteractiveMap.Core.Enums;
using InteractiveMap.Infrastructure.Identity.Defaults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/marks")]
public class MarkController : ApiControllerBase
{
    private readonly IBaseMarkService<Mark> _markService;

    public MarkController(IBaseMarkService<Mark> markService)
    {
        _markService = markService ?? throw new ArgumentNullException(nameof(markService));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<MarkBaseDto>>> GetAll([FromQuery] LayerType layerType)
    {
        var marks = await _markService.GetAllAsync(layerType);

        return Ok(marks);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<MarkDto>> GetById(int id)
    {
        var mark = await _markService.GetByIdAsync(id);

        return Ok(mark);
    }

    [HttpPost]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<ActionResult<int>> Create(MarkRequest request)
    {
        var id = await _markService.CreateAsync(request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<IActionResult> Update(int id, MarkRequest request)
    {
        await _markService.UpdateAsync(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        await _markService.DeleteAsync(id);

        return NoContent();
    }
}
