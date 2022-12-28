using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Ski
{
    Transform transform;
    Rigidbody rigidbody;
    CapsuleCollider collider;
    Vector3 scale;
    Vector3 localCenter;
    Quaternion localDirection;
    float drift;
    public Ski(GameObject gameObject, Vector3 center, Vector3 scale, float drift)
    {
        this.scale = scale;
        this.drift = drift;
        localDirection = Quaternion.LookRotation(Vector3.forward);
        localCenter = center;
        this.rigidbody = gameObject.GetComponent<Rigidbody>();
        this.transform = gameObject.transform;
        collider = gameObject.AddComponent<CapsuleCollider>();
        collider.center = center;
        collider.height = scale.z;
        collider.radius = scale.x * 0.5f;
        collider.direction = 2;
        collider.material.staticFriction = 0f;
        collider.material.dynamicFriction = 0f;
        collider.material.frictionCombine = PhysicMaterialCombine.Minimum;
    }
    public void SkiSlide(Vector3 normal, Vector3 point)
    {
        float frictionScalar = Vector3.Dot(transform.TransformDirection(localDirection * Vector3.right), -rigidbody.velocity) * scale.x * scale.z * 100 * drift;
        rigidbody.AddForceAtPosition(transform.right * frictionScalar, transform.TransformPoint(localCenter));
    }
    public void SkiRotate(float angle)
    {
        localDirection = Quaternion.Euler(0,angle,0);

    }
}
