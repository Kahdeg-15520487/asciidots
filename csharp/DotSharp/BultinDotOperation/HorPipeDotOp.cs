using System;
using System.Collections.Generic;
using System.Text;

namespace DotSharp.BultinDotOperation
{
    public class HorPipeDotOp : IDotOp
    {
        public char Symbol => '-';

        public bool Execute(DotCell cell, DotCell left, DotCell right, DotCell up, DotCell down)
        {
            var (dot, dir) = cell.AnyPort();
            cell.ResetPort();

            if (dir == Direction.right && left != null)
            {
                left.Right = dot;
                return true;
            }
            if (dir == Direction.left && right != null)
            {
                right.Left = dot;
                return true;
            }

            return false;
        }
    }
}
