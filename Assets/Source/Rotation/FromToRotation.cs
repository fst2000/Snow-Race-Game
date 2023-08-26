using System;
using UnityEngine;

public class FromToRotation : IRotation
{
    IVector3 from;
    IVector3 to;
    public FromToRotation(IVector3 from, IVector3 to)
    {
        this.from = from;
        this.to = to;
    }
    public void Accept(Action<Quaternion> action)
    {
        from.Accept(from =>
        {
            to.Accept(to =>
            {
                action(Quaternion.FromToRotation(from, to));
            });
        });
    }
}
