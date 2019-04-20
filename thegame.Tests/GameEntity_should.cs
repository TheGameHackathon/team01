using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using thegame.Models;

namespace thegame.Tests
{
    [TestFixture]
    class GameEntity_should
    {
        GameEntity gameEntity;

        [SetUp]
        public void SetUp()
        {
            gameEntity = GameEntity.CreateGameEntity(5);
        }

        [Test]
        public void ReturnPlayerPos()
        {
            var vec = gameEntity.GetPlayerPosition();

            Assert.That(vec.X, Is.EqualTo(2));
            Assert.That(vec.Y, Is.EqualTo(2));
        }

        [Test]
        public void ReturnFieldWidth()
        {
            var actual = gameEntity.GetWidth();

            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void ReturnFieldHeight()
        {
            var actual = gameEntity.GetHeight();

            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void ReturnReturnGameObjectInPosition()
        {
            var obj = gameEntity.GetObject(new Vec(2, 1));

            Assert.That(obj.Type, Is.EqualTo("box"));
        }

        [Test]
        public void ReturnScore()
        {
            var score = gameEntity.GetScore();

            Assert.That(score, Is.EqualTo(0));
        }
    }
}
