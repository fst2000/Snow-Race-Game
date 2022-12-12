using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Slide : MonoBehaviour
{
    [SerializeField] SnowCat snowCat;
    Vector3 collisionNormal;
    Vector3 collisionPoint;
    private void Start()
    {
        snowCat.Initialize(gameObject);
    }
    private void Update()
    {
        snowCat.Control();
    }
    void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contacts = collision.contacts;
        foreach (ContactPoint contact in contacts)
        {
            collisionNormal = contact.normal;
            collisionPoint = contact.point;
            snowCat.SnowCatSlide(contact.normal,contact.point);
            Debug.Log(contacts.Length);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(collisionPoint,collisionPoint + collisionNormal);
    }
}
