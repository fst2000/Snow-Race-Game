using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Slide : MonoBehaviour
{
    new Rigidbody rigidbody;
    PlayerInput playerInput;
    [SerializeField] float mass;
    [SerializeField] float driftIntencity;
    [SerializeField] float slideSpeed;
    void Start()
    {
        playerInput = new PlayerInput();
        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        rigidbody.mass = mass;
        rigidbody.angularDrag = 0.2f;
        rigidbody.centerOfMass = Vector3.zero;
    }
    void Update()
    {
        Vector3 forwardDirection = new Vector3(transform.forward.x,0,transform.forward.z).normalized;
        Vector3 slopeDirection = new Vector3(transform.up.x, 0, transform.up.z);
        float forwardScalar = -Vector3.Dot(transform.forward, Vector3.up);
        float slopeScalar = Vector3.Dot(transform.up, Vector3.up);
        Debug.Log(slopeScalar);
        if (Physics.CheckSphere(transform.position, 0.3f))
        {
            if (slopeScalar < 0.95f)
            {
                Vector3 slideVelocity = Vector3.Lerp(slopeDirection * (1 - slopeScalar), forwardDirection * forwardScalar, driftIntencity) * slideSpeed;
                rigidbody.velocity = new Vector3(slideVelocity.x, rigidbody.velocity.y, slideVelocity.z);
            }
        }
        rigidbody.AddRelativeForce(Vector3.forward * playerInput.MoveVertical * mass);
        transform.localRotation = transform.localRotation * Quaternion.Euler(0,playerInput.MoveHorizontal * Time.deltaTime * 40f,0);
    }
}
