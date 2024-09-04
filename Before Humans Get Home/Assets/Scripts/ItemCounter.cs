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
        if (collision.gameObject.CompareTag("Prop"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                counter++;
                UpdateCounterText();
            }
        }
    }
    private void UpdateCounterText()
    {
        if (counter != null)
        {
            counterText.text = "Count: " + counter;
        }
    }

    
}
