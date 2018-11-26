using System;
using System.Collections.Generic;
using System.Text;

namespace DotSharp.BultinDotOperation
{
    public class StartPipe : IDotPipe
    {
        public char Symbol => '.';

        public bool Execute(DotCell cell, DotCell left, DotCell right, DotCell up, DotCell down)
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
