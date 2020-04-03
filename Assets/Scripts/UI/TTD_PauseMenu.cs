using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TTD_PauseMenu : MonoBehaviour
{
	public static bool gameIsPaused = false;
	public GameObject pauseMenu;
	AudioSource audioSource;


	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) // Press ESC or P keys to Pause Game
		{
            if (gameIsPaused)
			{
				pauseMenu.SetActive(false);
				resumeGame();
			} else
			{
				pauseMenu.SetActive(true);
				pauseGame();
			}
		}
    }

	public void resumeGame() // Function called if the game is paused. Turns off pause menu, turns time back on.
	{
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void pauseGame() // Function called if the game is on. Turns on pause menu, turns time off.
	{
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
