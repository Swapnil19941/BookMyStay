using Microsoft.AspNetCore.Mvc;

namespace BookMyStay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        public HotelsController() { }

        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok("Welcome to hotels controller");
        }
    }
}
