using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int coins = 0;

    private 
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if(coins > Constants.maxCoins){
            coins = Constants.maxCoins;
        }else if(coins < 0){
            coins = 0;
        }
    }
}
