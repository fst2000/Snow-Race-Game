using System;
using UnityEngine;

public class DirectionVector3 : IVector3
{
    IVector3 position;
    Vector3 start;
    public DirectionVector3(IVector3 position)
    {
        this.position = position;
        position.Accept(v3 => start = v3);
    }
    public void Accept(Action<Vector3> action)
    {
        position.Accept(v3 =>
        {
            action(v3 - start);
            start = v3;
        });
    }
}