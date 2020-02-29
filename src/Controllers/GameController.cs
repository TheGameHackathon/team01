using Microsoft.AspNetCore.Mvc;

namespace thegame.Controllers
{
    [Route("game")]
    public class GameController : Controller
    {
        [HttpGet("{id}/score")]
        public IActionResult Score()
        {
            return Ok(50);
        }
    }
}
