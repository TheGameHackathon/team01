using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private readonly IGameRepo _gameRepo;

        public MovesController(IGameRepo gameRepo)
        {
            _gameRepo = gameRepo;
        }
        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var gameEntity = _gameRepo.Get(gameId);
            var key = char.ToLower(userInput.KeyPressed);
            var mapper = new Mapper();
            if (UserInputHandled(key))
                return new ObjectResult(mapper.Map(gameEntity, gameId));

            var sokoban = new Sokoban(gameEntity);

            sokoban.Move(GetDirection(key));

            _gameRepo.Save(gameEntity, gameId);
            return new ObjectResult(mapper.Map(gameEntity, gameId));
        }

        private bool UserInputHandled(char userInput)
        {
            switch (userInput)
            {
                case 'w':
                
                case 'a':

                case 's':

                case 'd':
                    return false;
            }
            return true;
        }

        private Direction GetDirection(char userInput)
        {
            switch (userInput)
            {
                case 'w':
                    return Direction.Up;
                case 'a':
                    return Direction.Left;
                case 's':
                    return Direction.Down;
                case 'd':
                    return Direction.Right;
            }
            throw new InvalidOperationException("Should not be here:(");
        }
    }
}