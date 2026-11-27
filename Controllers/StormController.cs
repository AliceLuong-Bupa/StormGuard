using Microsoft.AspNetCore.Mvc;
using StormGuard.Core;
using StormGuard.Core.Services;

namespace StormGuard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StormController : ControllerBase
    {
        private readonly StormDetectionService _stormDetectionService;

        public StormController()
        {
            _stormDetectionService = new StormDetectionService();
        }
        [HttpPost]
        public IActionResult ReceiveStorm(StormCell storm)
        {
            var riskLevel = _stormDetectionService.DetectRisk(storm);

            return Ok(new
            {
                message = "Storm data received and analysed",
                stormId = storm.StormId,
                windSpeedKmh = storm.WindSpeedKmh,
                riskLevel = riskLevel.ToString()
            });
        }
    }
}