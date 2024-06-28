using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody2D;
    Animator myAnimator;
    Collider2D myCollider2D;
    LayerMask ground;
    LayerMask ladder;
    float originalGravity;

    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    

    void Start()
    {  
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
        ground = LayerMask.GetMask("Ground");
        ladder = LayerMask.GetMask("Climbing");
        originalGravity = myRigidBody2D.gravityScale;
    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        // Debug.Log(moveInput);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, myRigidBody2D.velocity.y);
        myRigidBody2D.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
        
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && myCollider2D.IsTouchingLayers(ground))
        {
            myRigidBody2D.velocity += new Vector2(0f, jumpSpeed);
        }

        // if (myCollider2D.IsTouchingLayers(ground))
        // {
        //     Debug.Log("is touching ground");
        // }
    }

    void ClimbLadder()  
    {

        if (myCollider2D.IsTouchingLayers(ladder))
        {
            myRigidBody2D.gravityScale = 0;

            Vector2 climbVelocity = new Vector2(myRigidBody2D.velocity.x, moveInput.y * climbSpeed);
            myRigidBody2D.velocity = climbVelocity;
            
            bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody2D.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);

            // Debug.Log("is touching ladder");
        } 
        else
        {
            myRigidBody2D.gravityScale = originalGravity;
        }

    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidBody2D.velocity.x), 1);
            
        }
        
    }
}
