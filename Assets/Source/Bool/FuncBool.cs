using System;

public class FuncBool : IBool
{
    BoolFunc boolFunc;

    public FuncBool(BoolFunc boolFunc)
    {
        this.boolFunc = boolFunc;
    }

    public void Accept(Action<bool> action)
    {
        boolFunc(b => action(b));
    }
}