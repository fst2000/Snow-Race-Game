using System;
using UnityEngine;
public class SumVector3 : IVector3
{
    IVector3 first;
    IVector3 second;

    public SumVector3(IVector3 v1, IVector3 v2)
    {
        this.first = v1;
        this.second = v2;
    }   

    public void Accept(Action<Vector3> action)
    {
        first.Accept(f =>
            {
                second.Accept(s =>
                {
                    action(f + s);
                });
            }
        );
    }
}