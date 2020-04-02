using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int TOKEN_MAX = 10;
    private const int TOKEN_LOSS_ON_HIT = 3;

    [SerializeField]
    private int tokenCount;
    private PlayerMovement movement;    

    private Blessing blessing;
    private Blessing emptyBlessing = new Blessing();

    void Start()
    {
        tokenCount = 0;
        movement = gameObject.AddComponent(typeof(PlayerMovement)) as PlayerMovement;

        blessing = emptyBlessing;
    }

    public int GetLane()
    {
        return movement.GetLane();
    }

    public int GetTokens(){
        return tokenCount;
    }

    public void CollectToken()
    {
        if (tokenCount < TOKEN_MAX)
        {
            tokenCount++;
        }

        movement.SetSpeedMultiplier(1.0f + (float)tokenCount/10f);
    }

    private void LoseTokens(int count)
    {
        if (count > tokenCount)
        {
            tokenCount = 0;
        }
        else
        {
            tokenCount -= count;
        }
    }

    //----------Blessings--------------
    public Power GetPower()
    {
        return blessing.GetPower();
    }

    public void SetBlessing(Blessing newBlessing)
    {
        blessing = newBlessing;
    }

    public void UseBlessing(Player enemy)
    {
        blessing.UseBlessing(this, enemy);
        blessing = emptyBlessing;
    }

    public void Hit()
    {
        movement.Stumble();
        LoseTokens(TOKEN_LOSS_ON_HIT);
    }

    public void Reverse()
    {
        movement.Reverse();
    }

    public void Thunder(Object obj){
        GameObject spawned = (GameObject)Instantiate(obj);
        ThunderMovement follow = spawned.GetComponent<ThunderMovement>();
        follow.lookAt = transform;
        Destroy(spawned, 5f);
    }

    public void Invincible(){
        GetComponent<CharacterController>().detectCollisions = false;        
        Debug.Log("Going phantom");
        Invoke("Uninvincible", 5f);
    }

    private void Uninvincible(){
        Debug.Log("Back to reality");
        GetComponent<CharacterController>().detectCollisions = true;
    }
}
