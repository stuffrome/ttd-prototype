using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBorder : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == Constants.playerTag)
            GameManager.instance.Die();
    }
}
