namespace DotSharp
{
    public enum BuiltinDotOp
    {
        nop,
        start,
        end,
        pipeVer,
        pipeHor,
        mirrorUpLeft,
        mirrorUpRight,
        crossing,
        redirRight,
        redirLeft,
        redirUp,
        redirDown,
        reflectRight,
        reflectLeft,
        dup,
        prompt,
        noNewline,
        condition,
        notCondition,
        horOpLeft,
        horOpRight,
        verOpLeft,
        verOpRight,
        symbol,
        idMod,
        valueMod,
        filter0,
        filter1,
        literal,
        quote,
        quoteNoBuffer,
    }
}