using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowcatBehaviour : MonoBehaviour
{
    [SerializeField] Transform handlingSki;
    [SerializeField] float slideForce;
    Event fixedUpdate;
    new Rigidbody rigidbody;
    List<ContactPoint> contacts;
    bool hasCollision;
    void Start()
    {
        fixedUpdate = new Event();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        contacts = new();
    }
    void Update()
    {
        handlingSki.rotation = Quaternion.LookRotation(transform.forward, transform.up) * Quaternion.Euler(0, Input.GetAxis("Horizontal") * 60, 0);
    }
    void OnCollisionStay(Collision other)
    {
        other.GetContacts(contacts);
        hasCollision = true;
    }
    void FixedUpdate()
    {
        fixedUpdate.Call();
        if(hasCollision)
        {
            foreach(var contact in contacts)
            {
                Vector3 frictionDirection = Vector3.Cross(contact.thisCollider.transform.forward, contact.normal);
                float frictionScalar = Vector3.Dot(rigidbody.transform.right, rigidbody.velocity);
                Debug.DrawRay(contact.point, frictionDirection);
                rigidbody.AddForceAtPosition(frictionDirection * frictionScalar * slideForce, contact.point);
            }
        }
        hasCollision = false;
    }
}
