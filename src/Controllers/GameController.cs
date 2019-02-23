using Microsoft.AspNetCore.Mvc;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpGet("field")]
        public IActionResult GetField()
        {
            var map = new int[4, 4];
            map[1, 1] = 2;
            map[2, 3] = 2;
            return Ok(map);
        }
    }
}
