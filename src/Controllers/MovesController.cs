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
        public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
        {
            var game = GameCollection.Games[gameId];
            Color color = Color.Black;
            if (userInput.ClickedPos != null)
            {
                color = game.field.field[userInput.ClickedPos.X, userInput.ClickedPos.Y].Color;
                game.MakeStep(color, new Point(0, 0));
            }
                
            var cells = game.field
                .ConvertInOneLine()
                .Select(cell => new CellDto(cell.Id, new VectorDto(cell.Pos.X, cell.Pos.Y),
                    Palette.ConvertColor(cell.Color), "", 1)).ToArray();
            var gameDto = new GameDto(cells, false, true, game.field.Width, game.field.Height, game.Id, game.Finished(color), game.Score);
            return Ok(gameDto);
        }
    }
}