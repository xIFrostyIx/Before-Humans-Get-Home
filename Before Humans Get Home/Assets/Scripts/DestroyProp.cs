using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProp : MonoBehaviour
{
    public ItemCounter counter;
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            counter.itemCount--;
            counter.UpdateCounterText();
        }
    }
}
