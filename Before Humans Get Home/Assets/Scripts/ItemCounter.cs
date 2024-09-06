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
            SceneManager.LoadScene("Win");
        }
    }

    

    private void UpdateItemCount()
    {
        // Looks for objects with "Prop" tag
        itemCount = GameObject.FindGameObjectsWithTag("Prop").Length;
    }

    private void UpdateCounterText()
    {
        // Displays the number of "props"
        counterText.text = "Items Left: " + itemCount;
    }
}

