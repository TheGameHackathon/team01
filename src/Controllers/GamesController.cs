using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IMapper mapper;

        public GamesController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpPost]
        public IActionResult Index()
        {
            var game = new Game();
            var guid = Guid.NewGuid();
            game.Id = guid;
            var cells = game.field
                .ConvertInOneLine()
                .Select(cell => new CellDto(cell.Id, new VectorDto(cell.Pos.X,cell.Pos.Y), 
                    Palette.ConvertColor(cell.Color), "", 1)).ToArray();
            GameCollection.Games[guid] = game;
            var gameDto = new GameDto(cells, false, true, game.field.Width, game.field.Height, guid, false, 0);
            //var gameDto = mapper.Map<GameDto>(game);
            //var cells = game.field.ConvertInOneLine();
            //var cellsDto = mapper.Map<IEnumerable<CellDto>>(cells).ToArray();
            //gameDto.Cells = cellsDto;

            return Ok(gameDto);
        }
    }
}
