using Microsoft.AspNetCore.Mvc;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        private Game.Game game;

        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(100);
        }

        [HttpGet("field")]
        public IActionResult GetField()
        {
            game = new Game.Game(4, 4);
            return Ok(game.Map);
        }
    }
}
