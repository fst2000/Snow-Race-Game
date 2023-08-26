using System;
using UnityEngine;
public interface IVector2
{
    void Accept(Action<Vector2> action);
}
public delegate void Vector2Func(Action<Vector2> action);