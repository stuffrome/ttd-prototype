using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceToPlay : MonoBehaviour
{
    
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) // On the main menu, this function will load the in-game scene if the space bar s
		{
			SceneManager.LoadScene("Game");
		}
	}
}
