using UnityEngine;
using System;
public class ZeroVector3 : IVector3
{
    public void Accept(Action<Vector3> action)
    {
        action(Vector3.zero);
    }
}