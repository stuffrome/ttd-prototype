using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TTD_TutorialButtons : MonoBehaviour
{
	public GameObject tutorial1;
	public GameObject tutorial2;

	public void loadTut1() // Function called if the game is paused. Turns off pause menu, turns time back on.
	{
		tutorial1.SetActive(true);
		tutorial2.SetActive(false);
	}

	public void loadTut2() // Function called if the game is on. Turns on pause menu, turns time off.
	{
		tutorial1.SetActive(false);
		tutorial2.SetActive(true);
	}


	public void toMenu() // When the pause menu is up, this function will load the main menu scene.
	{
		SceneManager.LoadScene("TTD_StartScreen");
	}
}
