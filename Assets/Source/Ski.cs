using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Ski
{
    Vector3 localDirection;
    Vector3 localCenter;
    float drift;
    GameObject gameObject;
    Rigidbody rigidbody;
    CapsuleCollider collider;
    public Ski(GameObject gameobject, Vector3 localCenter, Vector3 size,int colliderAxis, float drift)
    {
        localDirection = Vector3.forward;
        this.localCenter = localCenter;
        this.drift = drift;
        this.gameObject = gameobject;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        
        collider = gameobject.AddComponent<CapsuleCollider>();
        collider.radius = (size.x + size.y) * 0.5f;
        collider.height = size.z;
        collider.center = localCenter;
        collider.direction = colliderAxis;
        collider.material.dynamicFriction = 0f;
        collider.material.staticFriction = 0f;
        collider.material.bounciness = 0f;
    }
    public void SkiSlide(Vector3 normal, Vector3 point)
    {
        Vector3 slopeDirection = new Vector3(normal.x, 0, normal.z).normalized;
        Vector3 skiDirection = gameObject.transform.TransformDirection(localDirection);
        Vector3 slideForce = Vector3.Lerp(skiDirection * Vector3.Dot(slopeDirection, skiDirection), slopeDirection, drift) * 5f;
        rigidbody.AddForceAtPosition(slideForce,point);
    }
    public void UpdateLocalDirection(Quaternion euler)
    {
        localDirection = euler * Vector3.forward;
    }
}
