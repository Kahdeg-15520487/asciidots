using System;
using System.Collections.Generic;
using System.Text;

namespace DotSharp.BultinDotOperation
{
    public class SetValuePipe : IDotPipe
    {
        public char Symbol => '#';

        public bool Execute(DotCell cell, DotCell left, DotCell right, DotCell up, DotCell down)
        {
            var (dot, dir) = cell.AnyPort();
            cell.ResetPort();

            dot.OnEnterCell = (d, c) =>
            {
                if (char.IsDigit(c.Symbol))
                {
                    d.Value = c.Symbol - 48;
                    d.OnEnterCell = null;
                }
                else
                {
                    throw new Exception($"{c.Symbol} is not a valid Value");
                }
            };

            return dot.Pipe(dir, left, right, up, down);
        }
    }
}
