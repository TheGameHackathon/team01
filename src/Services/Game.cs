using System;
using System.Drawing;

namespace thegame.Services
{
    public class Game
    {
        public Guid Id { get; set; }
        public Field field { get; set; }
        // public int Score { get; set; }
        
        public Game(int width = 10, int height = 10, int colorCount = 5)
        {
            
        }

        public void MakeStep(Color color, Point position)
        {
            throw new Exception();
        }
    }
}