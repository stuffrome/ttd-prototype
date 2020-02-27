using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int TOKEN_MAX = 10;

    private PlayerMovement movement;
    private Item item;
    private int tokenCount;


    void Start()
    {
        movement = gameObject.AddComponent(typeof(PlayerMovement)) as PlayerMovement;

        item = Item.None;
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

    public Item CurrentItem()
    {
        return item;
    }

    public void CollectItem(Item newItem)
    {
        if (item == Item.None)
        {
            item = newItem;
        }
    }
}
