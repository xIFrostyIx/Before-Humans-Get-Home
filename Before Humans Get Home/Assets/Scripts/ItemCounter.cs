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
    private Collider2D nearbyProp = null;
    private Animator propAnimator = null;
    
    // Start is called before the first frame update
    private void Start()
    {
        UpdateItemCount();
        UpdateCounterText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearbyProp != null)
        {
            HandlePropInteraction();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Prop"))
        {
            nearbyProp = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Prop") && other == nearbyProp)
        {
            nearbyProp = null;
        }
    }

    private void HandlePropInteraction()
    {
        if (nearbyProp != null)
        {
            // Decrease item count
            itemCount--;
            UpdateCounterText();

            // Animate prop
            propAnimator = nearbyProp.GetComponent<Animator>();
            if (propAnimator != null)
            {
                propAnimator.SetTrigger("Fall");
            }

            // Move the prop to the Ground layer
            nearbyProp.gameObject.layer = LayerMask.NameToLayer("Ground");

            // Clear the reference to the prop
            nearbyProp = null;

            if (itemCount <= 0)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }

    private void UpdateItemCount()
    {
        itemCount = GameObject.FindGameObjectsWithTag("Prop").Length;
    }

    private void UpdateCounterText()
    {
        counterText.text = "Items Left: " + itemCount;
    }
}

