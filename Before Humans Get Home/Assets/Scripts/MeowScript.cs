using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowScript : MonoBehaviour
{
    public AudioSource Meow;
    private bool canPlaySound = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && canPlaySound) 
        {
            StartCoroutine(PlayMeowSound());
        }
    }

    private IEnumerator PlayMeowSound()
    {
        canPlaySound = false;
        Meow.Play();
        yield return new WaitForSeconds(Meow.clip.length);
        canPlaySound = true;
    }
}
