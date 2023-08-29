using System;
using UnityEngine;

public class SkiBehaviour : MonoBehaviour
{
    [SerializeField] MultipleContact contact;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] float slideForce;
    Action gizmosAction;
    void FixedUpdate()
    {
        contact.Accept(contact =>
        {
            Vector3 frictionDirection = Vector3.Cross(contact.thisCollider.transform.forward, contact.normal);
            float frictionScalar = Vector3.Dot(rigidbody.transform.right, rigidbody.velocity);
            rigidbody.AddForceAtPosition(frictionDirection * frictionScalar * slideForce, contact.point);
        });
    }
}
