using NUnit.Framework;
using thegame.Models;

namespace thegame.Tests
{
    public class MovesController_should
    {
        [Test]
        public void NotFailWhenNullUserInput()
        {
            var userInput = new UserInputForMovesPost('c', null);
        }
    }
}
