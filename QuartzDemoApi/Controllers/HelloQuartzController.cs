using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuartzDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloQuartzController : ControllerBase
    {
        [HttpGet("RequestFromQuartz/{name}")]
        public async Task<IActionResult> RequestFromQuartz(string name)
        {
            Console.WriteLine("Inbound call from Scheduler");
            string message = $"Hello {name}";

            return Ok(message);
        }
    }
}
