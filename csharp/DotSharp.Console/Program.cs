using DotSharp.BultinDotOperation;
using System;
using System.IO;
using Cons = System.Console;

namespace DotSharp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Cons.WriteLine("no argument");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Cons.WriteLine("file does not exist");
                return;
            }

            var program = File.ReadAllText(args[0]);
            Cons.WriteLine(program);
            DotGrid grid = DotGridParser.Parse(program);
            grid.RegisterDotOperation(new HorPipe(), new VerPipe(), new MirrorUpLeft(), new MirrorUpRight(), new StartPipe(), new DebugPipe(), new SetValuePipe(), new SetIdPipe(), new BuiltinDotOperation.NopPipe());
            grid.Init();
            int step = 0;
            while (grid.Step())
            {
                Cons.WriteLine(step);
                step++;
            }
            Cons.WriteLine("ended");
            Cons.ReadLine();
        }
    }
}
