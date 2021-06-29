using System;
using System.Drawing;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
        {
            var game = GameCollection.Games[gameId];
            if (userInput?.KeyPressed != default(char))
            {
                game = HandleKeyboardPressing(userInput.KeyPressed, game);
                game.Id = gameId;
                GameCollection.Games[gameId] = game;
            }

            Color color = Color.Black;
            if (userInput?.ClickedPos != null)
            {
                if (userInput.ClickedPos.X < game.field.Width && userInput.ClickedPos.Y < game.field.Height)
                {
                    color = game.field.field[userInput.ClickedPos.X, userInput.ClickedPos.Y].Color;
                    game.MakeStep(color, new Point(0, 0));
                }
            }

            var cells = game.field
                .ConvertInOneLine()
                .Select(cell => new CellDto(cell.Id, new VectorDto(cell.Pos.X, cell.Pos.Y),
                    game.field.Palette.ConvertColor(cell.Color), "", 1)).ToArray();

            var gameDto = new GameDto(cells, true, true, game.field.Width, game.field.Height, game.Id, game.Finished(game.field.field[0,0].Color), game.Score);
            return Ok(gameDto);
        }

        private Game HandleKeyboardPressing(int key, Game game)
        {
            switch (key)
            {
                case 49:
                    return new Game(LevelDifficult.LowLevel);
                case 50:
                    return new Game(LevelDifficult.MiddleLevel);
                case 51:
                    return new Game(LevelDifficult.HighLevel);
            }

            if (key == 73)
            {
                game.MakeAIStep();
            }

            return game;
        }
    }
}