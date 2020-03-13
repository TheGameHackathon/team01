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
        private static GamesRepo repo = new GamesRepo();

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = repo.Field;

            string clickedColor;
            if (userInput.ClickedPos != null)
            {
                var clickedCell = game.GetCellAtCoords(userInput.ClickedPos.X, userInput.ClickedPos.Y);
                clickedColor = clickedCell.Type;

                foreach (var cell in game.Cells.Where(c => c.Type != clickedColor))
                {
                    cell.Type = clickedColor;
                    cell.Content = "*";
                }
            }

            repo.Field = game;
            return new ObjectResult(game);
        }
    }
}