namespace DotSharp
{
    static class ExtensionMethod
    {
        public static (DotCell left, DotCell right, DotCell up, DotCell down) GetSurround(this DotCell[,] grid, int width, int height, int x, int y)
        {
            DotCell left = x <= 0 ? null : grid[x - 1, y];
            DotCell right = x >= width - 1 ? null : grid[x + 1, y];
            DotCell up = y <= 0 ? null : grid[x, y - 1];
            DotCell down = y >= height - 1 ? null : grid[x, y + 1];
            return (left, right, up, down);
        }

        public static bool Pipe(this Dot dot, Direction dir,  DotCell left, DotCell right, DotCell up, DotCell down)
        {
            switch (dir)
            {
                case Direction.left:
                    if (right != null)
                    {
                        right.Left = dot;
                        return true;
                    }
                    break;
                case Direction.right:
                    if (left != null)
                    {
                        left.Right = dot;
                        return true;
                    }
                    break;
                case Direction.up:
                    if (down != null)
                    {
                        down.Up = dot;
                        return true;
                    }
                    break;
                case Direction.down:
                    if (up != null)
                    {
                        up.Down = dot;
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}