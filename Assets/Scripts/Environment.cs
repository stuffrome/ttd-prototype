using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Player player { get ; private set; }

    void Start()
    {
        FindPlayerComponent();
    }

    void Update()
    {

    }

    private void FindPlayerComponent()
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
