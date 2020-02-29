using System;
using Microsoft.AspNetCore.Mvc;
using thegame.DTO;
using thegame.Game.Domain;
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
        
        [HttpGet("{gameId}/score")]
        public IActionResult Score(Guid gameId)
        {
            var game = _repository.Find(gameId);
            if (game == null)
                return BadRequest();
            
            return Ok(game.Score);
        }

        [HttpPost("create")]
        public IActionResult CreateGame([FromBody] CreateGameDto data)
        {
            if (data == null
                || data.UserId.Equals(Guid.Empty)
                || data.FieldSize <= 0) 
                return BadRequest();

            if (_repository.IsUserHaveActiveGame(data.UserId, out var gameId))
            {
                var old = _repository.Find(gameId);
                _userRepository.UpdateUserScore(data.UserId, old.Score);
                _repository.Remove(gameId);
            }
            
            var id = _repository.CreateGame(data.UserId, data.FieldSize);
            return Ok(id);
        }

        [HttpPost("{gameId}")]
        public IActionResult MakeTurn(Guid gameId, [FromBody] TurnDto data)
        {
            if (gameId.Equals(Guid.Empty)) 
                return BadRequest();
            if (data.UserId.Equals(Guid.Empty))
                return Unauthorized();

            if (!_repository.IsUserPlayThisGame(data.UserId, gameId)) 
                return Unauthorized();
            if (!Enum.TryParse<ActionEnum>(data.Turn, out var turn))
                return BadRequest();
                
            return Ok(_repository.Find(gameId).ProcessAction(turn));

        }
        
        [HttpGet("{gameId}", Name = "GetFields")]
        public IActionResult GetField(Guid gameId)
        {
            if (gameId.Equals(Guid.Empty))
                return BadRequest();
            
            var game = _repository.Find(gameId);
            if (game == null)
                return NotFound();
            
            return Ok(game.Field);
        }
    }
}
