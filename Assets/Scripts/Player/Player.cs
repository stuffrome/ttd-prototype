using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int TOKEN_MAX = 10;
    private const int TOKEN_LOSS_ON_HIT = 3;

    private PlayerMovement movement;
    [SerializeField]
    private IItem item;
    [SerializeField]
    private int tokenCount;


    void Start()
    {
        movement = gameObject.AddComponent(typeof(PlayerMovement)) as PlayerMovement;

        // item = Item.None;
        item = new IItem();
        tokenCount = 0;
    }

    void Update()
    {

    }

    public int GetLane()
    {
        return movement.GetLane();
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

    public IItem CurrentItem()
    {
        return item;
    }

    public void CollectItem(IItem newItem)
    {
        item = newItem;
    }

    public void Hit()
    {
        movement.Stumble();
        LoseTokens(TOKEN_LOSS_ON_HIT);
    }

    public int GetTokens(){
        return tokenCount;
    }
}
