using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace thegame.Tests
{
    [TestFixture]
    class GameEntity_should
    {
        [Test]
        public void ReturnCorrectPlayerPos()
        {
            var gameEntity = GameEntity.CreateGameEntity(5);
            var vec = gameEntity.GetPlayerPosition();
            Assert.That(vec.X, Is.EqualTo(1));
            Assert.That(vec.Y, Is.EqualTo(1));
        }
    }
}
