using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;
    public int counter = 0;
    // Start is called before the first frame update
    private void Start()
    {
        if (counter == null)
        {
            Debug.LogError("CounterText is not assigned");
            return;
        }
        UpdateCounterText();
    }

    private void OnCollisisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the "Prop" tag
        if (collision.gameObject.CompareTag("Prop"))
        {
            // Check if the collision is with an object on the "Ground" layer
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                counter++; //Increment the counter
                UpdateCounterText(); //Update UI text
            }
        }
    }
    private void UpdateCounterText()
    {
        if (counter != null)
        {
            // Update the displayed count
            counterText.text = "Count: " + counter;
        }
    }

    
}
