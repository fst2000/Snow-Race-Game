using System;
using UnityEngine;

public class RayHit : IHit
{
    Vector3Func origin;
    Vector3Func direction;
    RaycastHit hit = new RaycastHit();
    public RayHit(IEvent fixedUpdate, Vector3Func origin, Vector3Func direction)
    {
        this.origin = origin;
        this.direction = direction;
        fixedUpdate.Subscribe(FixedUpdate);
    }
    public void Accept(Action<RaycastHit> action)
    {
        action(hit);
    }
    void FixedUpdate()
    {
        origin(origin => direction(direction =>
        {
            Physics.Raycast(origin, direction, out hit);
        }));
    }
}