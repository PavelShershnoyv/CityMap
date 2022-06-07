using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkImageService.Types;
using InteractiveMap.Application.Services.MarkService;
using InteractiveMap.Application.Services.MarkService.Types;
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
        var marks = await _markService.GetAllAsync(layerId);

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
        var id = await _markService.CreateAsync(UserId, request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMarkRequest request)
    {
        await _markService.UpdateAsync(id, request);

        return NoContent();
    }

    [HttpPost("{id}/images")]
    public async Task<ActionResult<string>> AddImage(int id, [FromForm] ImageRequest request)
    {
        var imageUrl = await _markService.AddImageAsync(id, request);

        return Ok(imageUrl);
    }

    [HttpDelete("{id}/images/{imageId}")]
    public async Task<IActionResult> DeleteImage(int id, int imageId)
    {
        await _markService.DeleteImageAsync(id, imageId);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _markService.DeleteAsync(id);

        return NoContent();
    }
}
