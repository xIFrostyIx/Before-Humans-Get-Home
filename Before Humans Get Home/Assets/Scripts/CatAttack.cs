using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : MonoBehaviour
{
     public string animationTriggerName = "PlayAnimation"; // Name of the trigger in the Animator

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider has an Animator component
        Animator animator = other.GetComponent<Animator>();

        if (animator != null)
        {
            // Play the animation by triggering the specified parameter
            animator.SetTrigger(animationTriggerName);
        }
    }
}
