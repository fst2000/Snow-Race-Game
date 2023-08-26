using System;
using UnityEngine;

public class ScaledVector3 : IVector3
{
    IVector3 vector3;
    FloatFunc scale;
    public ScaledVector3(IVector3 vector3, FloatFunc scale)
    {
        this.vector3 = vector3;
        this.scale = scale;
    }
    public void Accept(Action<Vector3> action)
    {
        vector3.Accept(v3 =>
        {
            scale(f => action(v3 * f));
        });
    }
}