using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace cloud_show_snatdemo_internal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly IInternalCallService _internalCallService;

        public DemoController(ILogger<DemoController> logger,
        IInternalCallService callService)
        {
            _logger = logger;
            _internalCallService = callService;
        }

        [HttpGet("/internal")]
        public async Task<IActionResult> CallingInternalAsync(){
            await _internalCallService.GetInternalResponse();
            return Ok();
        }
    }
}