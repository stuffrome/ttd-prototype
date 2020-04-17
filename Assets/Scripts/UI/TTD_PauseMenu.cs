using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TTD_PauseMenu : MonoBehaviour
{
	public static bool gameIsPaused = false;
	public static bool gameIsRunning = true;
	public GameObject pauseMenu;
	AudioSource audioSource;


	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) // Press ESC or P keys to Pause Game
		{
			if (gameIsRunning) {
				if (gameIsPaused)
				{
					resumeGame();
				} else
				{
					pauseGame();
				}
			}
		}
    }

	public void resumeGame() // Function called if the game is paused. Turns off pause menu, turns time back on.
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void pauseGame() // Function called if the game is on. Turns on pause menu, turns time off.
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void toMenu() // When the pause menu is up, this function will load the main menu scene.
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("TTD_StartScreen");
	}

	public void quitGame() // When the pause menu is up, this function will quit the game.
	{
		Application.Quit();
	}
}
