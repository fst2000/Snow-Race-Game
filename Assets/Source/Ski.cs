using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Ski
{
    Vector3 localCenter;
    Vector3 size;
    float drift;
    BoxCollider collider;
    Rigidbody rigidbody;
    public Ski(GameObject gameobject, Vector3 localCenter, Vector3 size,float drift)
    {
        this.localCenter = localCenter;
        this.size = size;
        this.drift = drift;
        collider =  gameobject.AddComponent<BoxCollider>();
        collider.center = localCenter;
        collider.size = size;
        rigidbody = gameobject.GetComponent<Rigidbody>();
    }
    public void Slide()
    {
        rigidbody.AddRelativeForce(Vector3.forward);
    }
}
