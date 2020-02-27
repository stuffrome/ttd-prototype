using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Player player { get ; private set; }

    void Start()
    {
        player = GetPlayerObject().GetComponent<Player>();
    }

    void Update()
    {

    }

    public GameObject GetPlayerObject()
    {
        GameObject playerGO = null;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.tag == Constants.tagPlayer)
            {
                playerGO = child.gameObject;
            }
        }

        return playerGO;
    }
}
