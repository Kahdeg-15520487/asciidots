using System;
using System.Collections.Generic;

namespace DotSharp
{
    public class DotGrid
    {
        private readonly int GridHeight;
        private readonly int GridWidth;

        public DotCell[,] Grid { get; private set; }
        public Dictionary<char, IDotPipe> DotOps { get; private set; }
        public DotGrid(int width, int height)
        {
            GridHeight = height;
            GridWidth = width;
            Grid = new DotCell[width, height];
            DotOps = new Dictionary<char, IDotPipe>();
        }

        public void RegisterDotOperation(params IDotPipe[] dotOps)
        {
            foreach (var dotOp in dotOps)
            {
                //todo check existing dotOp
                DotOps.Add(dotOp.Symbol, dotOp);
            }
        }

        public void SetGridData(DotCell[,] gridData)
        {
            var dataWidth = gridData.GetLength(0);
            var dataHeight = gridData.GetLength(1);
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Grid[x, y] = x < dataWidth && y < dataHeight ? gridData?[x, y] : default(DotCell);
                }
            }
        }

        public bool Init()
        {
            bool isAnyDotActive = false;
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    if (Grid[x, y].Symbol == '.')
                    {
                        var (left, right, up, down) = Grid.GetSurround(GridWidth, GridHeight, x, y);
                        var dotOp = DotOps['.'];
                        isAnyDotActive = dotOp.Execute(Grid[x, y], left, right, up, down);
                    }
                }
            }
            return isAnyDotActive;
        }

        public bool Step()
        {
            bool isAnyDotActive = false;
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    //Console.WriteLine(Grid[x, y].IsActive);
                    if (Grid[x, y].IsActive)
                    {
                        Grid[x, y].AnyPort().dot.IsStepped = true;
                        var (left, right, up, down) = Grid.GetSurround(GridWidth, GridHeight, x, y);
                        var cell = Grid[x, y];
                        var symbol = cell.Symbol;
                        Console.WriteLine(symbol);
                        if (DotOps.ContainsKey(symbol))
                        {
                            var dotOp = DotOps[symbol];
                            isAnyDotActive |= dotOp.Execute(cell, left, right, up, down);
                        }
                        else
                        {
                            //check if literal symbol
                            if (symbol >= '0' && symbol <= '9')
                            {
                                //execute the on enter dot event
                                var (dot, dir) = cell.AnyPort();
                                cell.ResetPort();

                                dot.OnEnterCell?.Invoke(dot, cell);

                                isAnyDotActive |= dot.Pipe(dir, left, right, up, down);
                            }
                            else
                            {
                                throw new InvalidOperationException(symbol.ToString());
                            }
                        }
                    }
                }
            }
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Grid[x, y].AnyPort().dot.IsStepped = false;
                }
            }
            return isAnyDotActive;
        }
    }
}