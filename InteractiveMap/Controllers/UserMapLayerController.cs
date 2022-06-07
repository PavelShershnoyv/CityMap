using InteractiveMap.Application.Services.MapLayerService;
using InteractiveMap.Application.Services.MapLayerService.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/user-layers")]
[Authorize]
public class UserMapLayerController : ApiControllerBase
{
    private readonly IUserMapLayerService _mapLayerService;

    public UserMapLayerController(IUserMapLayerService mapLayerService)
    {
        _mapLayerService = mapLayerService ?? throw new ArgumentNullException(nameof(mapLayerService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MapLayerBaseDto>>> GetAll()
    {
        var mapLayers = await _mapLayerService.GetAllAsync(UserId);

        return Ok(mapLayers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapLayerDto>> GetById(int id)
    {
        var mapLayer = await _mapLayerService.GetByIdAsync(id);

        return Ok(mapLayer);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] MapLayerRequest request)
    {
        var id = await _mapLayerService.CreateAsync(UserId, request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMapLayerRequest request)
    {
        await _mapLayerService.UpdateAsync(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mapLayerService.DeleteAsync(id);

        return NoContent();
    }
}
