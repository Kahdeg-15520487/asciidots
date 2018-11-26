using System;
using System.Collections.Generic;
using System.Text;

namespace DotSharp.BultinDotOperation
{
    public class MirrorUpRight : IDotPipe
    {
        public char Symbol => '/';

        public bool Execute(DotCell cell, DotCell left, DotCell right, DotCell up, DotCell down)
        {
            var (dot, dir) = cell.AnyPort();
            cell.ResetPort();

            switch (dir)
            {
                case Direction.right:
                    return dot.PipeToPort(Direction.up, down);
                case Direction.left:
                    return dot.PipeToPort(Direction.down, up);
                case Direction.down:
                    return dot.PipeToPort(Direction.left, right);
                case Direction.up:
                    return dot.PipeToPort(Direction.right, left);
            }
            return false;
        }
    }
}
