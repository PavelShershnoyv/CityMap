using InteractiveMap.Application.MapLayerService;
using InteractiveMap.Application.MapLayerService.Types;
using InteractiveMap.Infrastructure.Identity.Defaults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/layers")]
public class MapLayerController : ApiControllerBase
{
    private readonly IMapLayerService _mapLayerService;

    public MapLayerController(IMapLayerService mapLayerService)
    {
        _mapLayerService = mapLayerService ?? throw new ArgumentNullException(nameof(mapLayerService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MapLayerBaseDto>>> GetAll()
    {
        var mapLayers = await _mapLayerService.GetLayersAsync();

        return Ok(mapLayers);
    }

    [HttpGet]
    public async Task<ActionResult<MapLayerDto>> GetByTitle([FromQuery] string title)
    {
        var mapLayer = await _mapLayerService.GetLayerAsync(title);

        return Ok(mapLayer);
    }

    [HttpPost]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<ActionResult<string>> Create([FromBody] MapLayerRequest request)
    {
        var title = await _mapLayerService.CreateLayerAsync(request);

        return Ok(title);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] MapLayerRequest request)
    {
        await _mapLayerService.UpdateLayerAsync(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mapLayerService.DeleteLayerAsync(id);

        return NoContent();
    }
}
