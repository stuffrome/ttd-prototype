using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public int segmentId { set; get; }
    public bool transition;
    public int length;

    private Obstacle[] obstacles;

    private TerrainBlock terrain;

    private void Awake()
    {
        obstacles = gameObject.GetComponentsInChildren<Obstacle>();
    }

    public void SpawnWith(TerrainBlock t)
    {
        terrain = t;

        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.Spawn();
        }
        terrain.Spawn();
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.Despawn();
        }
        terrain.DeSpawn();
        gameObject.SetActive(false);
    }
}
