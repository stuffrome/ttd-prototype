using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int TOKEN_MAX = 10;

    private PlayerMovement movement;
    private int tokenCount;


    void Start()
    {
        movement = gameObject.AddComponent(typeof(PlayerMovement)) as PlayerMovement;
    }

    void Update()
    {

    }

    public void collectToken() {
        if (tokenCount < TOKEN_MAX) {
            tokenCount++;
        }

    }
}
