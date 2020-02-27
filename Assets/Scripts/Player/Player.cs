using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement movement;


    void Start()
    {
        movement = gameObject.AddComponent(typeof(PlayerMovement)) as PlayerMovement;
    }

    void Update()
    {

    }
}
