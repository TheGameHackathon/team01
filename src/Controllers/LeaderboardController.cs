using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.DTO;
using thegame.Leaderboard;

namespace thegame.Controllers
{
    [Route("leaderboard")]
    public class LeaderboardController : Controller
    {
        private IUserRepository _board;
        public LeaderboardController(IUserRepository board)
        {
            _board = board;
        }
        
        [HttpGet]
        public IActionResult GetLeaderboard()
        {
            var board = _board.GetAllUsers()
                .Select(x => new LeaderboardUserDto()
            {
                Name = x.Name,
                Score = x.Score
            })
                .ToArray();
            return Ok(board);
        }
    }
}