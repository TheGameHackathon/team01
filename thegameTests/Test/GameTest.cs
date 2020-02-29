using System.Linq;
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
            var game = new Game(new[,]
            {
                {0},
                {1},
                {1}
            });

            game.ProcessAction(ActionEnum.down);
            game.Field[2, 0].Should().Be(2);
        }

        [TestCase(ActionEnum.down)]
        [TestCase(ActionEnum.left)]
        [TestCase(ActionEnum.right)]
        [TestCase(ActionEnum.up)]
        public void Should_DontMergeCellsWithDifferentValueOnAction(ActionEnum action)
        {
            var game = new Game(new int[,]
            {
                {4, 1},
                {2, 3}
            });

            game.ProcessAction(action);
            game.Field.As1DArray().Should().BeEquivalentTo(new[] {4, 1, 2, 3});
        }

        [Test]
        public void ShouldNot_MergeThreeAndMoreCellsInOne()
        {
            var game = new Game(new[,]
            {
                {0},
                {6},
                {3},
                {3}
            });
            game.ProcessAction(ActionEnum.down);
            game.Field[2, 0].Should().Be(6);
            game.Field[3, 0].Should().Be(6);
        }

        [Test]
        public void Should_AddNewCell_AtRandomPlaceAfterEveryStep()
        {
            var game = new Game(new[,]
            {
                {0},
                {0},
                {0},
                {0}
            });
            game.ProcessAction(ActionEnum.left);
            game.ProcessAction(ActionEnum.left);
            game.ProcessAction(ActionEnum.left);
            game.ProcessAction(ActionEnum.left);
            game.Field.As1DArray().Min().Should().NotBe(0);
        }

        [Test]
        public void Should_OverGame_WhenNoZeroCells()
        {
            var game = new Game(new [,]
            {
                {1},
                {1}
            });
            game.ProcessAction(ActionEnum.down);
            game.IsOver.Should().BeTrue();
        }

        [Test]
        public void Should_Update_MaxScore()
        {
            var game = new Game(new [,]
            {
                {0, 3, 2, 1},
                {8, 2, 2, 4}
            });
            game.ProcessAction(ActionEnum.right);
            game.ProcessAction(ActionEnum.right);
            game.ProcessAction(ActionEnum.right);
            game.Score.Should().Be(16);
        }
    }
}