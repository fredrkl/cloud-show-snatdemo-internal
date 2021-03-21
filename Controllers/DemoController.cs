using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace cloud_show_snatdemo_internal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly IInternalCallService _internalCallService;
        private readonly IConfiguration _configuration;

        public DemoController(ILogger<DemoController> logger,
        IInternalCallService callService,
        IConfiguration config)
        {
            _logger = logger;
            _internalCallService = callService;
            _configuration = config;
        }

        [HttpGet("/internal")]
        public async Task<IActionResult> CallingInternalAsync(){
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(_configuration["InternalCallBaseUri"]);
            await client.GetStringAsync("");
            return Ok();
        }
    }
}