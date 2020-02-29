using System;

namespace thegame.DTO
{
    public class CreateGameDto
    {
        public Guid UserId { get; set; }
        public int FieldSize { get; set; }
    }
}