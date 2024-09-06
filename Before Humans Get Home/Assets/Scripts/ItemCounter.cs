using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;
    public int itemCount;


    // Start is called before the first frame update
    private void Start()
    {
        UpdateItemCount();
        UpdateCounterText();
    }

    private void Update()
    {
        if (itemCount <= 0)
        {
            SceneManager.LoadScene("NxtLvl");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Check if the player collided with a "Prop"
            if (other.gameObject.CompareTag("Prop"))
            {
                // Decrease the item count
                itemCount--;

                // Update the counter text
                UpdateCounterText();

                // Destroy the object that was collided with
                Destroy(other.gameObject);

                // Check if all items are collected
                if (itemCount <= 0)
                {
                    // Load the win scene
                    SceneManager.LoadScene("NxtLvl");
                }
            }
        }
    }

    private void UpdateItemCount()
    {
        // Looks for objects with "Prop" tag
        itemCount = GameObject.FindGameObjectsWithTag("Prop").Length;
    }

    public void UpdateCounterText()
    {
        // Displays the number of "props"
        counterText.text = "Items Left: " + itemCount;
    }
}

