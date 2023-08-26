using System;
using UnityEngine;

public class HitNormalVector3 : IVector3
{
    IHit hit;

    public HitNormalVector3(IHit hit)
    {
        this.hit = hit;
    }

    public void Accept(Action<Vector3> action)
    {
        hit.Accept(hit =>
        {
            action(hit.normal);
        });
    }
}