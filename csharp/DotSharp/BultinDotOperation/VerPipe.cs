using System;
using System.Collections.Generic;
using System.Text;

namespace DotSharp.BultinDotOperation
{
    public class VerPipe : IDotPipe
    {
        public char Symbol => '|';

        public bool Execute(DotCell cell, DotCell left, DotCell right, DotCell up, DotCell down)
        {
            var (dot, dir) = cell.AnyPort();
            cell.ResetPort();

            if (dir == Direction.up && down != null)
            {
                down.Up = dot;
                return true;
            }
            if (dir == Direction.down && up != null)
            {
                up.Down = dot;
                return true;
            }

            return false;
        }
    }
}
