using System;
using System.Drawing;

namespace thegame.Services
{
    public class Game
    {
        public Field field { get; set; }
        // public int Score { get; set; }
        
        public Game(int width, int height, int colorCount)
        {
            
        }

        public void MakeStep(Color color, Point position)
        {
            throw new Exception();
        }
    }
}