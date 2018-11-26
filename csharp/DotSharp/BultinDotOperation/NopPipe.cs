namespace DotSharp.BuiltinDotOperation
{
    public class NopPipe : IDotPipe
    {
        public char Symbol => ' ';

        public bool Execute(DotCell cell, DotCell left, DotCell right, DotCell up, DotCell down)
        {
            return false;
        }
    }
}