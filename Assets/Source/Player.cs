using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class Player
{
    Transform transform;
    Rigidbody rigidbody;
    Animator animator;
    PlayerInput playerInput;
    [SerializeField] float walkSpeed = 2f;
    public void Initialize(GameObject gameObject)
    {
        transform = gameObject.transform;
        playerInput = new PlayerInput();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void Update()
    {
        Move();
    }
    void Move()
    {
        if(playerInput.WalkInput != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            transform.rotation = Quaternion.LookRotation(playerInput.WalkInput);
            Vector3 velocity = rigidbody.velocity;
            rigidbody.velocity = new Vector3(playerInput.WalkInput.x * walkSpeed, velocity.y, playerInput.WalkInput.z * walkSpeed);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
