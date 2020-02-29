using NUnit.Framework;
using FluentAssertions;
using thegame.Game.Domain;

namespace thegame.Test
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        void Should_DontChangeGameField_WhenGetState()
        {
            var game = new Game.Domain.Game(new int[,]
            {
                {0, 1},
                {0, 1}
            });

            game.Field.Should().BeEquivalentTo(new int[,]
            {
                {0, 1},
                {0, 1}
            });
        }

        [Test]
        void Should_MergeCellsWithSameValueOnAction()
        {
            var game = new Game.Domain.Game(new int[,]
            {
                {0, 1},
                {0, 1}
            });

            game.ProcessAction(ActionEnum.down);
            game.Field[1, 1].Should().Be(2);
        }

        [TestCase(ActionEnum.down)]
        [TestCase(ActionEnum.left)]
        [TestCase(ActionEnum.right)]
        [TestCase(ActionEnum.up)]
        void Should_DontMergeCellsWithDifferentValueOnAction(ActionEnum action)
        {
            var game = new Game.Domain.Game(new int[,]
            {
                {0, 1},
                {2, 3}
            });

            game.ProcessAction(action);
            game.Field.Create1DArray().Should().BeEquivalentTo(new int[] {0, 1, 2, 3});
        }
    }
}