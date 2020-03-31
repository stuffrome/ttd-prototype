using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TTD_PauseMenu : MonoBehaviour
{
	public static bool gameIsPaused = false;
	public GameObject pauseMenu;
	AudioSource audioSource;


	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
            if (gameIsPaused)
			{
				resumeGame();
			} else
			{
				pauseGame();
			}
		}
    }

	public void resumeGame()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void pauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void toMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("TTD_StartScreen");
	}

	public void quitGame()
	{
		Application.Quit();
	}

    public void muteAudio()
	{
		audioSource.mute = !audioSource.mute;
	}
}
