using Microsoft.AspNetCore.Mvc;
using CatchSmart.Core.Services;

namespace CatchSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionApiController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionApiController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [Route("get-positions")]
        [HttpGet]
        public IActionResult GetPosition(string title)
        {
            var position = _positionService.GetPositionByName(title);
            return Ok(position);
        }
    }
}
