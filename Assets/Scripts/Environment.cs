using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public SegmentGenerator segmentGenerator;

    public Player player { get; private set; }

    private GameObject playerObject;

    private void Start()
    {
        playerObject = GetPlayerObject();
        player = playerObject.GetComponent<Player>();
        SetupSegmentGenerator();
    }

    private void Update() {
        segmentGenerator.UpdateSegments(playerObject.transform.position);
    }

    private void SetupSegmentGenerator()
    {
        Vector3 startPosition = playerObject.transform.position;
        segmentGenerator.Setup(startPosition, Constants.segmentSpawnCount);
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

    public float GetPlayerProgress(){
        return segmentGenerator.GetSegmentProgress();
    }
}
