using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToLoad : MonoBehaviour
{
	public void LoadTutorial_1()
	{
		SceneManager.LoadScene("TTD_Tutorial1");
    }

	public void LoadTutorial_2()
	{
		SceneManager.LoadScene("TTD_Tutorial2");
	}

	public void LoadTutorial_3()
	{
		SceneManager.LoadScene("TTD_Tutorial3");
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("TTD_StartScreen");
	}
}