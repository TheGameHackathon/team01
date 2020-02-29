using System;

namespace thegame.Game.Domain
{
    public class GameUser
    {
        public string Nickname { get; set; }
        
        public Guid Id {
            get;
            set;
        }
    }
}