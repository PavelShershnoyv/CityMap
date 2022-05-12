using InteractiveMap.Application.MapLayerService;
using InteractiveMap.Application.MapLayerService.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/layers")]
public class MapLayerController : ApiController
{
    private readonly IPublicMapLayerService _mapLayerService;

    public MapLayerController(IPublicMapLayerService mapLayerService)
    {
        _mapLayerService = mapLayerService ?? throw new ArgumentNullException(nameof(mapLayerService));
    }

    [HttpGet]
    public async Task<ActionResult<MapLayerListDto>> GetAll()
    {
        var mapLayers = await _mapLayerService.GetLayersAsync();

        return Ok(mapLayers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<int>> Get(int id)
    {
        var mapLayer = await _mapLayerService.GetLayerAsync(id);

        return Ok(mapLayer);
    }

    [HttpPost("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<int>> Create(MapLayerRequest request)
    {
        var id = await _mapLayerService.CreateLayerAsync(request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, MapLayerRequest request)
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
