using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToLoad : MonoBehaviour
{
	public void LoadTutorial()
	{
		SceneManager.LoadScene("TTD_Tutorial");
    }

	public void LoadMenu()
	{
		SceneManager.LoadScene("TTD_StartScreen");
	}
}