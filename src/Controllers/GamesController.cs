using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private IGameRepo gameRepo;

        public GamesController(IGameRepo gameRepo)
        {
            this.gameRepo = gameRepo;
        }

        [HttpPost]
        public IActionResult Index()
        {
            var gameEntity = GameEntity.CreateGameEntity(5);
            var gameId = Guid.NewGuid();
            gameRepo.Save(gameEntity, gameId);
            var mapper = new Mapper();
            return new ObjectResult(mapper.Map(gameEntity, gameId));
        }
    }
}
