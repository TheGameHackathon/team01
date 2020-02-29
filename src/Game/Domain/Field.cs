using System.Linq;

namespace thegame.Game.Domain
{
    public class Field
    {
        public int maxScore { get; set; }
        public int[,] field { get; set; }

        Field()
        {
            field = new int[4, 4];
            for(var i=0; i<4; ++i)
            for(var j = 0; j < 4; ++j)
                field[i, j] = Randomizer.GenerateInitCell();
        }

        Field(int[,] field)
        {
            for(var i=0; i<4; ++i)
            for (var j = 0; j < 4; ++j)
                this.field[i, j] = field[i, j];
        }
    }
}