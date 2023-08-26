using System;
using UnityEngine;

public class BoneRotation : IRotation
{
    IRotation rotation;
    Quaternion quaternion;
    Action<Quaternion> qAction = q => {};
    bool accepted;
    public BoneRotation(IRotation rotation, IEvent lateUpdate)
    {
        this.rotation = rotation;
        lateUpdate.Subscribe(LateUpdate);
    }
    public void Accept(Action<Quaternion> action)
    {
        qAction = action;
        rotation.Accept(q => quaternion = q);
        accepted = true;
    }
    void LateUpdate()
    {
        if(accepted)
        {
            qAction(quaternion);
            accepted = false;
        }
    }
}