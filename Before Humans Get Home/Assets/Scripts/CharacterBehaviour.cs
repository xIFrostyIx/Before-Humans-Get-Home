using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    //Allows movement speed to be tweaked in unity
    public float movementSpeed;
    public float jumpingForce;

    //references rigid body component
    private Rigidbody2D rb;
    //Sets default direction the player is facing
    private bool facingRight = true;
    private float movementDirections;
    private bool isJumping =  false;

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
        if (Input.GetButtonDown("Jump"))
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

    private void flipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 0f, 180f);
    }
}
