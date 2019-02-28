using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 7f;
    float airMovement = 5f; //higher is slower
    public float maxSpeed = 8f;
    float maxMag = 8f;
    float jumpForce = 8f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    GameObject goPlayer;
    float groundRadius = 0.35f;

    Rigidbody2D rb;

    [HideInInspector]
    public bool grounded = false;
    bool facingRight = true;
    [HideInInspector]
    bool physicsBased = false;
    

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for movement.
        //Check if player is jumping.
        //Check if player is on the ground.

        float movement = Input.GetAxis("Horizontal"); //grab movement from input
        Vector2 moveVector = new Vector2(movement, 0); //convert to a Vector2
        
        checkFlip(movement); //check if player is facing a different direction, and flip if necessary
        checkIfGrounded(); //check if player is grounded
        
        if (Input.GetKeyDown("space") && grounded) //if player has pressed space, and is on the ground, then jump
        {
            jump();
        }
      
        if (!grounded) //if not grounded dvide movement by air movement
        {
            moveVector = moveVector / airMovement; 
        }

        if (physicsBased)
        {
            rb.AddForce(moveVector * speed);
            limitVelocity();
        }
        else
        {
            goPlayer.transform.Translate((Input.GetAxis("Horizontal")) * 0.1f, 0, 0);
        }
        
    }

    private void limitVelocity()
    {
        Vector2 v = rb.velocity;
        float mag = rb.velocity.magnitude;
        //Debug.Log("Magnitude: " + mag);
        if (mag>maxMag)
        {
            speed = 0;
        }
        else
        {
            speed = maxSpeed;
        }
    }

    void checkIfGrounded()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void checkFlip(float movement)
    {
        if ((movement > 0 && !facingRight) || (movement < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void jump()
    {
        Vector2 jumpVec = new Vector2(0, jumpForce);
        // Debug.Log("Jump");
        rb.AddForce(jumpVec, ForceMode2D.Impulse);

        grounded = false;
    }
}
