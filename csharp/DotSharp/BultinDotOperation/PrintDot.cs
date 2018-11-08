﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotSharp.BultinDotOperation
{
    public class PrintDot : IDotOp
    {
        public char Symbol => '$';

        public bool Execute(DotCell cell, DotCell left, DotCell right, DotCell up, DotCell down)
        {
            var (dot, dir) = cell.AnyPort();
            cell.ResetPort();
            Console.WriteLine(dot == null ? "nil" : dot.ToString());
            return false;
        }
    }
}
