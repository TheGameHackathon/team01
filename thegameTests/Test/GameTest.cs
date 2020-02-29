using FluentAssertions;
using NUnit.Framework;
using thegame.Game.Domain;

namespace thegameTests.Test
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void Should_DontChangeGameField_WhenGetState()
        {
            var game = new Game(new int[,]
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
        public void Should_MergeCellsWithSameValueOnAction()
        {
            var game = new Game(new int[,]
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
        public void Should_DontMergeCellsWithDifferentValueOnAction(ActionEnum action)
        {
            var game = new Game(new int[,]
            {
                {0, 1},
                {2, 3}
            });

            game.ProcessAction(action);
            game.Field.Create1DArray().Should().BeEquivalentTo(new[] {0, 1, 2, 3});
        }

        [Test]
        public void ShouldNot_MergeThreeAndMoreCellsInOne()
        {
            var game = new Game(new [,]
            {
                {2},
                {1},
                {1}
            });
            game.ProcessAction(ActionEnum.down);
            game.Field[2, 0].Should().Be(2);
            game.Field[1, 0].Should().Be(2);
        }
    }
}