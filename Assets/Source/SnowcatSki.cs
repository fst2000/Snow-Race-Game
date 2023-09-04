using UnityEngine;
public class SnowcatSki : ISki
{
    GameObject ski;
    IContact skiContact;
    Vector3 center;
    Vector3 size;
    CapsuleCollider collider;

    public SnowcatSki(GameObject ski, IContact snowcatContact, Vector3 center, float radius, float length)
    {
        PhysicMaterial skiMaterial = new PhysicMaterial();
        skiMaterial.dynamicFriction = 0;
        skiMaterial.staticFriction = 0;
        skiMaterial.frictionCombine = PhysicMaterialCombine.Maximum;
        skiMaterial.bounciness = 0;
        collider = ski.AddComponent<CapsuleCollider>();
        collider.center = center;
        collider.direction = 2;
        collider.radius = radius;
        collider.height = length;
        collider.material = skiMaterial;
        skiContact = new ColliderContact(snowcatContact, collider);
    }
    public void Slide(float slideForce, float friction)
    {
        skiContact.Accept(contact =>
        {
            Transform transform = ski.transform;
            Rigidbody rigidbody = ski.GetComponent<Rigidbody>();
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