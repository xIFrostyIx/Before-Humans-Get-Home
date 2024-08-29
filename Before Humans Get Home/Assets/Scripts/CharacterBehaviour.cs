using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    //Allows movement speed to be tweaked in unity
    public float movementSpeed;

    //references rigid body component
    private Rigidbody2D rb;
    //Sets default direction the player is facing
    private bool facingRight = true;

    // Awake is called after all objects are initialized
    private void Awake()
    {
        //Will look for component attached to player
        rb = GetComponent<Rigidbody2D>();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
