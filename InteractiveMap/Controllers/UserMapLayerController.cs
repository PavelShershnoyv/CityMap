using InteractiveMap.Application.MapLayerService;
using InteractiveMap.Application.MapLayerService.Types;
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
        var mapLayers = await _mapLayerService.GetLayersAsync(UserId);

        return Ok(mapLayers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapLayerDto>> GetById(int id)
    {
        var mapLayer = await _mapLayerService.GetLayerAsync(UserId, id);

        return Ok(mapLayer);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] MapLayerRequest request)
    {
        var id = await _mapLayerService.CreateLayerAsync(UserId, request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MapLayerRequest request)
    {
        await _mapLayerService.UpdateLayerAsync(UserId, id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mapLayerService.DeleteLayerAsync(UserId, id);

        return NoContent();
    }
}
