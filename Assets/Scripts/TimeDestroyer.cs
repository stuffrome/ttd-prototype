using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour
{
    public float lifeTime = 10f;

    void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }

    void DestroyObject()
    {
        if (GameManager.instance.gameState != GameState.Dead) {
            Destroy(gameObject);
        }
    }
}
