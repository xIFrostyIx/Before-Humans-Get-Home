using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch : MonoBehaviour
{
   
    public void GoToLevelOne()
    {
        SceneManager.LoadScene("Lvl 1");
    }
}
