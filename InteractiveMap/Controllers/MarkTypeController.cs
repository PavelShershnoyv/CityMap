using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkTypeService.Types;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers
{
    [Route("api/mark-types")]
    public class MarkTypeController : ApiControllerBase
    {
        private readonly IMarkTypeService _markTypeService;

        public MarkTypeController(IMarkTypeService markTypeService)
        {
            _markTypeService = markTypeService ?? throw new ArgumentNullException(nameof(markTypeService));
        }

        [HttpGet]
        public async Task<ActionResult<MarkTypeBaseDto>> GetAll()
        {
            var markTypes = await _markTypeService.GetMarkTypesAsync();

            return Ok(markTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarkTypeDto>> GetById(int id)
        {
            var markType = await _markTypeService.GetMarkTypeAsync(id);

            return Ok(markType);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] MarkTypeRequest request)
        {
            var id = await _markTypeService.CreateMarkType(request);

            return CreatedAtAction(nameof(GetById), new { id = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MarkTypeRequest request)
        {
            await _markTypeService.UpdateMarkTypeAsync(id, request);

            return Ok();
        }
    }
}
