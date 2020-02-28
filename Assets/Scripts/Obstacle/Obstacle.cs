using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    None = -1,
    Normal = 0,
    Jump = 1,
    Slide = 2
}

public class Obstacle : MonoBehaviour
{
    public ObstacleType type;

    public void Spawn()
    {

        // obstacle = SegmentSpawner.Instance.GetObstacle(type);
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
    }
}
