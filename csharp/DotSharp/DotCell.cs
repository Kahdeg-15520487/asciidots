namespace DotSharp
{
    public class DotCell
    {
        /// <summary>
        /// the symbol of this dot cell
        /// </summary>
        public char Symbol { get; }

        /// <summary>
        /// the left port of this dot cell
        /// </summary>
        public Dot Left { get; set; }
        /// <summary>
        /// the right port of this dot cell
        /// </summary>
        public Dot Right { get; set; }
        /// <summary>
        /// the up port of this dot cell
        /// </summary>
        public Dot Up { get; set; }
        /// <summary>
        /// the down port of this dot cell
        /// </summary>
        public Dot Down { get; set; }

        /// <summary>
        /// is this dot cell active
        /// </summary>
        public bool IsActive => Left != null || Right != null || Up != null || Down != null;

        public DotCell(char symbol = ' ')
        {
            Symbol = symbol;
        }

        public void ResetPort()
        {
            Left = null;
            Right = null;
            Up = null;
            Down = null;
        }

        public (Dot dot, Direction dir) AnyPort()
        {
            if (Left != null)
            {
                return (Left, Direction.left);
            }
            if (Right != null)
            {
                return (Right, Direction.right);
            }
            if (Up != null)
            {
                return (Up, Direction.up);
            }
            if (Down != null)
            {
                return (Down, Direction.down);
            }
            return (null, Direction.none);
        }
    }
}