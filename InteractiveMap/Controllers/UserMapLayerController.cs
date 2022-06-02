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
    [Authorize]
    public async Task<ActionResult<MapLayerListDto>> GetAll()
    {
        var mapLayers = await _mapLayerService.GetLayersAsync(CurrentUserService.UserId);

        return Ok(mapLayers);
    }

    [HttpGet]
    public async Task<ActionResult<MapLayerDto>> Get(int id)
    {
        var mapLayer = await _mapLayerService.GetLayerAsync(CurrentUserService.UserId, id);

        return Ok(mapLayer);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] MapLayerRequest request)
    {
        var id = await _mapLayerService.CreateLayerAsync(CurrentUserService.UserId, request);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MapLayerRequest request)
    {
        await _mapLayerService.UpdateLayerAsync(CurrentUserService.UserId, id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mapLayerService.DeleteLayerAsync(CurrentUserService.UserId, id);

        return NoContent();
    }
}
