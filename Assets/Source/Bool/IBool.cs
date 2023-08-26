using System;
public interface IBool
{
    void Accept(Action<bool> action);
}
public delegate void BoolFunc(Action<bool> action);