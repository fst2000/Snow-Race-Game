using System;
using UnityEngine;

public class LookRotation : IRotation
{
    IVector3 direction;
    public LookRotation(IVector3 direction)
    {
        this.direction = direction;
    }
    public void Accept(Action<Quaternion> action)
    {
        direction.Accept(v3 =>
        {
            if(v3 != Vector3.zero)
            {
                action(Quaternion.LookRotation(v3));
            }
        });
    }
}
