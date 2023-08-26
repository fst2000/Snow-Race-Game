using System;
public interface IFloat
{
    void Accept(Action<float> action);
}
public delegate void FloatFunc(Action<float> action);