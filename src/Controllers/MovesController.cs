using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

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
            var mapper = new Mapper();
            if (UserInputHandled(userInput))
                return new ObjectResult(mapper.Map(gameEntity, gameId));

            var sokoban = new Sokoban(gameEntity);

            sokoban.Move(GetDirection(userInput));
            //var game = TestData.AGameDto(userInput.ClickedPos ?? new Vec(1, 1));
            //if (userInput.ClickedPos != null)
            //    game.Cells.First(c => c.Type == "player").Pos = userInput.ClickedPos;

            _gameRepo.Save(gameEntity, gameId);
            return new ObjectResult(mapper.Map(gameEntity, gameId));
        }

        private bool UserInputHandled(UserInputForMovesPost userInput)
        {
            switch (userInput.KeyPressed)
            {
                case 'w':
                
                case 'a':

                case 's':

                case 'd':
                    return false;
            }
            return true;
        }

        private Direction GetDirection(UserInputForMovesPost userInput)
        {
            switch (userInput.KeyPressed)
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