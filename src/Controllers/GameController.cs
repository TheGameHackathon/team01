using System;
using Microsoft.AspNetCore.Mvc;
using thegame.DTO;
using thegame.Leaderboard;
using thegame.Repository;

namespace thegame.Controllers
{
    [Route("game")]
    public class GameController : Controller
    {
        private readonly IGameRepository _repository;
        private readonly IUserRepository _userRepository;
        public GameController(IGameRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
        
        [HttpGet("{id}/score")]
        public IActionResult Score(string id)
        {
            return Ok(50);
        }

        [HttpPost("create")]
        public IActionResult CreateGame([FromBody] CreateGameDto data)
        {
            if (data == null
                || data.UserId.Equals(Guid.Empty)
                || data.FieldSize <= 0) 
                return BadRequest();
            
            var id = _repository.CreateGame(data.UserId, data.FieldSize);
            return Ok(id);
        }

        [HttpPost("{userId}")]
        public IActionResult MakeTurn(string userId, [FromBody] string turn)
        {
            return Ok();
        }
        
        [HttpGet("{id}")]
        public IActionResult GetField(string id)
        {
            var temp = new int[10, 10];
            temp[0, 3] = 5;
            temp[5, 5] = 3;
            temp[4, 4] = 4;
            temp[0, 3] = 57;
            temp[8, 7] = 65;
            return Ok(temp);
        }
    }
}
