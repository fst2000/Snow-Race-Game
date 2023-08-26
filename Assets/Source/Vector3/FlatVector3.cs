using System;
using UnityEngine;

public class FlatVector3 : IVector3
{
    IVector3 vector3;

    public FlatVector3(IVector3 vector3)
    {
        this.vector3 = vector3;
    }

    public void Accept(Action<Vector3> action)
    {
        vector3.Accept(v3 => action(new Vector3(v3.x, 0, v3.z).normalized * v3.magnitude));
    }
}