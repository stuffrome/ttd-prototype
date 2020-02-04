using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        // If the player hits an obstacle
        if(col.gameObject.tag == Constants.playerTag)
        {
            // Needs to be changed into slowin down the player
            GameManager.instance.Die();
        }
    }
}
