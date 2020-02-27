using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private Player player;

    void Start()
    {
        GetPlayer();
    }

    void Update()
    {

    }

    private void GetPlayer()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.tag == Constants.tagPlayer)
            {
                player = child.gameObject.GetComponent<Player>();
            }
        }
    }
}
