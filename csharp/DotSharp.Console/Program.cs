using DotSharp.BultinDotOperation;
using System;
using Cons = System.Console;

namespace DotSharp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DotGrid grid = DotGridParser.Parse(".-@1#3-$");
            grid.RegisterDotOperation(new HorPipeDotOp(), new VerPipeDotOp(), new StartDot(), new PrintDot(), new SetValueDot(), new SetIdDot());
            grid.Init();
            while (grid.Step())
            {
            }

            Cons.ReadLine();
        }
    }
}
