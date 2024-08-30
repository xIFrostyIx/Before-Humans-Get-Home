using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Created By: Joshua Guerrero
 * This script adds player movement and jumping.
 */

public class CharacterBehaviour : MonoBehaviour
{
    //Allows movement speed to be tweaked in unity
    public float movementSpeed;
    public float jumpingForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;

    //references rigid body component
    private Rigidbody2D rb;
    //Sets default direction the player is facing
    private bool facingRight = true;
    private float movementDirections;
    private bool isJumping =  false;
    private bool isGround;

    // Awake is called after all objects are initialized
    private void Awake()
    {
        //Will look for component attached to player
        rb = GetComponent<Rigidbody2D>();
    }
   
    // Update is called once per frame
    void Update()
    {
        //get inputs
        movementDirections = Input.GetAxis("Horizontal"); // Scale of -1 to 1
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isJumping = true;
        }

        //Animate
        if (movementDirections > 0 && !facingRight)
        {
            flipCharacter();
        }
        else if (movementDirections < 0 && facingRight)
        {
            flipCharacter();
        }

        //movement
        rb.velocity = new Vector2(movementDirections * movementSpeed, rb.velocity.y);
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpingForce));
        }
        isJumping = false;
    }

    private void FixedUpdate()
    {
        //check if grounded
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
    }


    private void flipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 0f, 180f);
    }
}
