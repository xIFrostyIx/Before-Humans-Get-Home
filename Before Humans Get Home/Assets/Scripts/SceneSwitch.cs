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

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}
