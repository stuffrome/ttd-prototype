using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public int segmentId { set; get; }
    public bool transition;
    public int length;

    private Obstacle[] obstacles;

    private void Awake()
    {
        obstacles = gameObject.GetComponentsInChildren<Obstacle>();
    }

    public void Spawn()
    {
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.Spawn();
        }
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.Despawn();
        }
        gameObject.SetActive(false);
    }
}
