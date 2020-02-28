using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private const int DEFAULT_SEGMENT_COUNT = 85;

    public SegmentGenerator segmentGenerator;

    public Player player { get; private set; }


    void Start()
    {
        player = GetPlayerObject().GetComponent<Player>();
        SetupObstacles();
    }

    private void SetupObstacles()
    {
        Vector3 startPosition = GetPlayerObject().transform.position;
        segmentGenerator.GenerateSegments(startPosition, DEFAULT_SEGMENT_COUNT);
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
