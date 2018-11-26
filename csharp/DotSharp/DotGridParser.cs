using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotSharp
{
    public class DotGridParser
    {
        public static DotGrid Parse(string src)
        {
            var (data, width, height) = Split2D(src);

            DotCell[,] cells = new DotCell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new DotCell(data[x, y]);
                }
            }

            DotGrid grid = new DotGrid(width, height);
            grid.SetGridData(cells);
            return grid;
        }

        public static (char[,] data, int width, int height) Split2D(string str)
        {
            var data = str.Replace("\r\n", "\n").Replace("\n\r", "\n").Split('\n').Select(line => line.ToCharArray()).ToList();

            var width = data.Max(line => line.Length);
            var height = data.Count;

            var result = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result[x, y] = x < data[y].Length ? data[y][x] : ' ';
                }
            }

            return (result, width, height);
        }
    }
}
