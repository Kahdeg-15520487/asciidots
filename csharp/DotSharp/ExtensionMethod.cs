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

        public static bool PipeToPort(this Dot dot,Direction destPort,DotCell dest)
        {
            if (dest!=null)
            {
                switch (destPort)
                {
                    case Direction.left:
                        dest.Left = dot;
                        return true;
                    case Direction.right:
                        dest.Right = dot;
                        return true;
                    case Direction.up:
                        dest.Up = dot;
                        return true;
                    case Direction.down:
                        dest.Down = dot;
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// pipe the dot through a port in current cell
        /// </summary>
        /// <returns>whether or not the dot can go</returns>
        public static bool Pipe(this Dot dot, Direction dir, DotCell left, DotCell right, DotCell up, DotCell down)
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


        /// <summary>
        /// pipe the dot through any port in current cell
        /// </summary>
        /// <returns>whether or not the dot can go</returns>
        public static bool PipeAny(this Dot dot, DotCell left, DotCell right, DotCell up, DotCell down)
        {
            if (left != null)
            {
                left.Right = new Dot();
                return true;
            }
            if (right != null)
            {
                right.Left = new Dot();
                return true;
            }
            if (up != null)
            {
                up.Down = new Dot();
                return true;
            }
            if (down != null)
            {
                down.Up = new Dot();
                return true;
            }

            return false;
        }
    }
}