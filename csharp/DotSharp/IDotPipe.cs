namespace DotSharp
{
    public interface IDotPipe
    {
        /// <summary>
        /// the symbol of this dot cell
        /// </summary>
        char Symbol { get; }

        /// <summary>
        /// execute this dot operation
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="up"></param>
        /// <param name="down"></param>
        /// <returns>Is the dot that passed to this op still exist</returns>
        bool Execute(DotCell cell,DotCell left, DotCell right, DotCell up, DotCell down);
    }
}