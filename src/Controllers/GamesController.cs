using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            var game = new Game(LevelDifficult.HighLevel);
            var guid = Guid.NewGuid();
            game.Id = guid;
            var cells = game.Field
                .ConvertInOneLine()
                .Select(cell => new CellDto(cell.Id, new VectorDto(cell.Pos.X,cell.Pos.Y), 
                    game.Field.Palette.ConvertColor(cell.Color), "", 1)).ToArray();
            GameCollection.Games[guid] = game;


            var gameDto = new GameDto(cells, true, true,
                game.Field.Width, game.Field.Height, guid, false, game.Score);

            return Ok(gameDto);
        }
    }
}
