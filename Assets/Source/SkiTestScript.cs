using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiTestScript : MonoBehaviour
{
   [SerializeField] new Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;
    PlayerInput playerInput;
    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.material.frictionCombine = PhysicMaterialCombine.Minimum;
        capsuleCollider.material.staticFriction = 0.01f;
        capsuleCollider.material.dynamicFriction = 0.01f;
        rigidbody.velocity = Vector3.forward;
    }
    private void FixedUpdate()
    {
        rigidbody.AddForceAtPosition(transform.up, transform.position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 5f);
    }
}
