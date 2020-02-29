
namespace thegame.Game.Domain
{
    public static class ArrayExtension
    {
        public static int[,] Create2DArray(this int[] arr, int width, int height)
        {
            var res = new int[width, height];
            for (var i = 0; i < height; ++i)
            for (var j = 0; j < width; ++j)
                res[i, j] = arr[i * width + j];
            return res;
        }

        public static int[] Create1DArray(this int[,] arr)
        {
            var height = arr.GetLength(0);
            var width = arr.GetLength(1);
            var res = new int[height * width];
            for (var i = 0; i < height; ++i)
            for (var j = 0; j < width; ++j)
                res[i * width + j] = arr[i, j];
            return res;
        }

        public static void Swap(this int[,] arr, int i1, int j1, int i2, int j2)
        {
            var temp = arr[i1, j1];
            arr[i1, j1] = arr[i2, j2];
            arr[i2, j2] = temp;
        }

        public static bool IsInBorders(this int[,] arr, int i, int j)
        {
            var height = arr.GetLength(0);
            var width = arr.GetLength(1);
            return 0 <= i && i < height && 0 <= j && j < width;
        }
    }
}