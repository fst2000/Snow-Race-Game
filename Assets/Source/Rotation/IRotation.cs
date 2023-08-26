using System;
using UnityEngine;
public interface IRotation
{
    void Accept(Action<Quaternion> action);
}
public delegate void RotationFunc(Action<Quaternion> action);