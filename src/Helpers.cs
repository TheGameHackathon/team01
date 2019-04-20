using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame
{
    public class Helpers
    {

        public static Vec Move(Vec pos, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    return new Vec(pos.X - 1, pos.Y);
                case Direction.Right:
                    return new Vec(pos.X + 1, pos.Y);
                case Direction.Up:
                    return new Vec(pos.X, pos.Y - 1);
                case Direction.Down:
                    return new Vec(pos.X, pos.Y + 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }
    }
}
