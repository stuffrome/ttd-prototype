using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Environment env1, env2;
    public TextMeshProUGUI p1Score, p2Score;

    private void Start()
    {
        
    }

    void Update(){
        p1Score.text = env1.player.GetTokens().ToString("0");
        p2Score.text = env2.player.GetTokens().ToString("0");
    }

    public void Quit(){
        Application.Quit();
    }
}
