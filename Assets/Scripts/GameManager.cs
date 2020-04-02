using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Environment env1, env2;
    public TextMeshProUGUI p1Score, p2Score;//, p1Item, p2Item;

    private void Start()
    {
        
    }

    void Update(){
        p1Score.text = env1.player.GetTokens().ToString("0");
        p2Score.text = env2.player.GetTokens().ToString("0");
        // p1Item.text = env1.player.GetPower().ToString("");
        // p2Item.text = env2.player.GetPower().ToString("");
    }

    public void Quit(){
        Application.Quit();
    }
}
