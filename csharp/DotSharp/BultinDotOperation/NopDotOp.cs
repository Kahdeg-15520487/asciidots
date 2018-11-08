namespace DotSharp.BuiltinDotOperation
{
    public class NopDotOp : IDotOp
    {
        public char Symbol => ' ';

        public bool Execute(DotCell cell, DotCell left, DotCell right, DotCell up, DotCell down)
        {
            return false;
        }
    }
}