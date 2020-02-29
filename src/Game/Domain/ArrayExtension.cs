using FluentAssertions;
using NUnit.Framework;

namespace thegame.Game.Domain
{
    public static class ArrayExtension
    {
        public static int[,] CreateFrom(this int[] arr, int width, int height)
        {
            arr.Length.Should().Be(width * height);
            var res = new int[width, height];
            for(var i=0; i<height; ++i)
            for(var j = 0; j < width; ++j)
                res[i, j] = arr[i * width + j];
            return res;
        }
    }
}