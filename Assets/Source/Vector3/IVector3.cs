using System;
using UnityEngine;
public interface IVector3
{
    void Accept(Action<Vector3> action);
}
public delegate void Vector3Func(Action<Vector3> action);
public delegate void IVector3Func(Action<IVector3> action);