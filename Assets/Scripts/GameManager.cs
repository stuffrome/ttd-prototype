using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Environment env1, env2;
    public TextMeshProUGUI p1Score, p2Score;
    public GameObject[] p1Item, p2Item;

    void Update(){
        p1Score.text = env1.player.GetTokens().ToString("0");
        p2Score.text = env2.player.GetTokens().ToString("0");
        updateItem(p1Item, env1.player.GetPower());
        updateItem(p2Item, env2.player.GetPower());
    }

    private void updateItem(GameObject[] UI, Power power){
        switch(power){
            case Power.Reverse :
                toggleUI(UI, 2);
                break;
            case Power.Thunder :
                toggleUI(UI, 1);
                break;
            case Power.Phantm :
                toggleUI(UI, 0);
                break;
            default :
                toggleUI(UI, 3);
                break;
        }
    }

    private void toggleUI(GameObject[] UI, int index){
        for(int i=0;i<UI.Length;i++){
            if(i==index){
                UI[i].SetActive(true);
            }else{
                UI[i].SetActive(false);
            }
        }
    }

    public void Quit(){
        Application.Quit();
    }
}
