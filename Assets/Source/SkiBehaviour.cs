using System;
using UnityEngine;

public class SkiBehaviour : MonoBehaviour
{
    [SerializeField] MultipleContact contact;
    [SerializeField] new Collider collider;
    ColliderContact colliderContact;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] float slideForce;
    [SerializeField] float friction;
    void Start()
    {
        colliderContact = new ColliderContact(contact, collider);
    }
    void FixedUpdate()
    {
        colliderContact.Accept(contact =>
        {
            Vector3 slideForceDirection = Vector3.Cross(contact.thisCollider.transform.forward, contact.normal);
            float frictionScalar = Vector3.Dot(transform.right, rigidbody.GetPointVelocity(contact.point));
            rigidbody.AddForceAtPosition(slideForceDirection * frictionScalar * slideForce, contact.point);
            Vector3 frictionDirection = -rigidbody.GetPointVelocity(contact.point);
            rigidbody.AddForceAtPosition(frictionDirection * friction, contact.point);

            Debug.DrawRay(contact.point, slideForceDirection * frictionScalar, Color.green);
            Debug.DrawRay(contact.point + transform.up * 0.2f, frictionDirection * friction, Color.red);
        });
    }
}
