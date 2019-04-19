using System;
using NUnit.Framework;
using thegame.Controllers;
using thegame.Models;

namespace thegame.Tests
{
    public class MovesController_should
    {
        [Test]
        public void NotFailWhenNullUserInput()
        {
            var userInput = new UserInputForMovesPost('c', null);
            Assert.DoesNotThrow(() => new MovesController().Moves(Guid.NewGuid(), userInput));
        }
    }
}
