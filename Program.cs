using System;
using System.Text;

namespace Challenge6
{
    internal class Program
    {
        public static void TurnSquareArray(int[,] array)
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            if (n != m) throw new ArgumentException("Array must be square.");

            int max = n - 1;

            var rotated = new int[n, n];       // <- temp buffer to avoid overwrite
            var sb = new StringBuilder();
            sb.Append("array[] = [");

            for (int i = 0; i < n; i++)
            {
                sb.Append("[");
                for (int j = 0; j < n; j++)
                {
                    // 90° clockwise mapping: (i, j) -> (j, N-1-i)
                    int ni = j;
                    int nj = max - i;

                    // move the value to the new location
                    rotated[ni, nj] = array[i, j];

                    // keep your instructions string
                    sb.Append($"[{ni}, {nj}]");
                    if (j < n - 1) sb.Append(", ");
                }
                sb.Append("]");
                if (i < n - 1) sb.Append(", ");
            }
            sb.Append("]");

            // copy rotated back into the original array
            Array.Copy(rotated, array, rotated.Length);

            // Show the instruction string (optional)
            Console.WriteLine(sb.ToString());

            // (Optional) print the rotated array to verify
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                    Console.Write(array[r, c] + " ");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] array =
            {
                { 1, 2, 3, 4 },
                { 4, 5, 6, 4 },
                { 7, 8, 9, 4 },
                { 4, 5, 6, 3 }
            };
            TurnSquareArray(array);
        }
    }
}

