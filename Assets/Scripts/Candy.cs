using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public int scorePoints = 100;
    public float rotateSpeed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter(Collider col)
    {
        UIManager.instance.IncreaseScore(scorePoints);
        Destroy(this.gameObject);
    }
}