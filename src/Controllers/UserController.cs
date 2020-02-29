using System;
using Microsoft.AspNetCore.Mvc;
using thegame.DTO;
using thegame.Leaderboard;

namespace thegame.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateUserDto data)
        {
            if (data == null
                || string.IsNullOrEmpty(data.Username)
                || string.IsNullOrEmpty(data.Password))
                return BadRequest();

            var id =_repository.AddUser(data.Username, data.Password);
            if (id.Equals(Guid.Empty))
                return BadRequest();
            return Ok(id);
        }

        [HttpGet("id")]
        public IActionResult GetUserId([FromBody] CreateUserDto data)
        {
            if (!_repository.IsUserAuthorized(data.Username, data.Password)) 
                return Unauthorized();
            
            var id = _repository.GetUserId(new User(data.Username, data.Password));
            return Ok(id);
        }
    }
}