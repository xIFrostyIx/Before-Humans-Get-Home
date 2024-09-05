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

    private void OnCollisionEnter2D(Collider2D other)
    {
        if (other.CompareTag("Prop"))
        {
            itemCount--;
            UpdateCounterText();

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
