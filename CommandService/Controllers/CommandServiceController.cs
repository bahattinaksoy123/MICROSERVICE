using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [ApiController]
    [Route("api/commandservice/v1/[controller]")]
    public class PlatformServiceController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok("Successfully PlatformServiceController is worked in CommandService :)");
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");
            return Ok("Inbound test from PlatformController in Command Service is worked.");
        }
    }
}