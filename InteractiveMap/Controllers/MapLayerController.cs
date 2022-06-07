using InteractiveMap.Application.Services.MapLayerService;
using InteractiveMap.Application.Services.MapLayerService.Types;
using InteractiveMap.Core.Entities;
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
        var mapLayers = await _mapLayerService.GetAllAsync();

        return Ok(mapLayers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapLayerDto>> GetById(int id)
    {
        var mapLayer = await _mapLayerService.GetByIdAsync(id);

        return Ok(mapLayer);
    }

    [HttpPost]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<ActionResult<string>> Create([FromBody] MapLayerRequest request)
    {
        var title = await _mapLayerService.CreateAsync(request);

        return Ok(title);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMapLayerRequest request)
    {
        await _mapLayerService.UpdateAsync(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = RoleDefaults.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        await _mapLayerService.DeleteAsync(id);

        return NoContent();
    }
}
