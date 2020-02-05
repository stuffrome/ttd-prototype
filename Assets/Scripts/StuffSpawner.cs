﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour
{
    //points where stuff will spawn :)
    public Transform[] StuffSpawnPoints;
    //meat gameobjects
    public GameObject[] Bonus;
    //obstacle gameobjects
    public GameObject[] Obstacles;

    public bool RandomX = false;
    public float minX = -2f, maxX = 2f;

    void Start()
    {
        bool placeObstacle = Random.Range(0, 2) == 0; //50% chances
        int obstacleIndex = -1;
        if (placeObstacle)
        {
            //select a random spawn point, apart from the first one
            //since we do not want an obstacle there
            obstacleIndex = Random.Range(1, StuffSpawnPoints.Length);

            CreateObject(StuffSpawnPoints[obstacleIndex].position, Obstacles[Random.Range(0, Obstacles.Length)]);
        }

        for (int i = 0; i < StuffSpawnPoints.Length; i++)
        {
            //don't instantiate if there's an obstacle
            if (i == obstacleIndex) continue;
            if (Random.Range(0, 3) == 0) //33% chances to create candy
            {
                CreateObject(StuffSpawnPoints[i].position, Bonus[Random.Range(0, Bonus.Length)]);
            }
        }

    }



    void CreateObject(Vector3 position, GameObject prefab)
    {
        if (RandomX) //true on the straight paths level, false on the rotated one
            position += new Vector3(Random.Range(minX, maxX), 0, 0);

        Instantiate(prefab, position, Quaternion.identity);
    }
}
