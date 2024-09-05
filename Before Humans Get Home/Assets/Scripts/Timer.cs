using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*Created by: Joshua Guerrero
/*Purpose: Script sets a timer that can be altered in the Inspector
*/

public class Timer : MonoBehaviour
{	
   [SerializeField] TextMeshProUGUI timerText;
   [SerializeField] float remainingTime;
	[SerializeField] string sceneName = "You Lose";

   void Update()
   {
		//Stops the timer from going into the negatives
		if (remainingTime > 0)
		{
			remainingTime -= Time.deltaTime;
		}
		else if (remainingTime < 0)
		{
			remainingTime = 0;
			//End Game function
			SceneManager.LoadScene(sceneName);
		}

		//Formats the timer
		 int minutes = Mathf.FloorToInt(remainingTime / 60);
		 int seconds = Mathf.FloorToInt(remainingTime % 60);
		 timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   }
}
