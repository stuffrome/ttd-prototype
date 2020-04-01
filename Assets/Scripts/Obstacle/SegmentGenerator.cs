using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    private const int CONTINUOUS_SEGS_MAX = 5;
    private const int DEFAULT_SEGMENT_LENGTH = 10;
    private const int MAX_SPAWN_DISTANCE = 100;
    private const int DESPAWN_BUFFER = 20;
    private const int TERRAIN_LENGTH = 6;
    private const int TRANSITION_COUNT = 10;


    private int activeSegCount;
    private int continuousSegCount;
    private int spawnedSegsCount;

    private Vector3 spawnPoint;

    public List<Segment> availableSegs = new List<Segment>();
    public List<Segment> availableTrans = new List<Segment>();
    private List<Segment> activeSegs = new List<Segment>();

    public List<TerrainBlock> terrainList = new List<TerrainBlock>();


    public void SetStartPosition(Vector3 startPosition) {
        spawnPoint = startPosition;
    }

    public void UpdateSegments(Vector3 playerPosition) {
        SpawnSegmentsAhead(playerPosition);
        DespawnSegmentsBehind(playerPosition);
    }

    public void SpawnSegmentsAhead(Vector3 playerPosition) {
        if (spawnPoint.z - playerPosition.z < MAX_SPAWN_DISTANCE) {
            GenerateSegment();
        }
    }

    public void DespawnSegmentsBehind(Vector3 playerPosition) {
        for (int i = activeSegs.Count - 1; i >=0; i--)
        {
            if (activeSegs[i].transform.position.z < playerPosition.z - DESPAWN_BUFFER) {
                activeSegs[i].Despawn();
                activeSegs.RemoveAt(i);
            }
        }
    }

    private void GenerateSegment() {
        if (spawnedSegsCount < 3) {
            SpawnTransition();
        }
        else
        {
            if (continuousSegCount < CONTINUOUS_SEGS_MAX)
            {
                SpawnSegment();
                continuousSegCount++;
            }
            else
            {
                SpawnTransition();
                continuousSegCount = 0;
            }
        }
    }

    private void SpawnSegment()
    {
        int id = Random.Range(0, availableSegs.Count);

        Segment segment = GetSegment(id, false);
        TerrainBlock terrain = GetTerrain();

        segment.transform.position = spawnPoint;
        terrain.transform.position = spawnPoint;

        spawnPoint.z += DEFAULT_SEGMENT_LENGTH;
        activeSegCount++;
        spawnedSegsCount++;
        segment.SpawnWith(terrain);
    }

    private void SpawnTransition()
    {
        int id = Random.Range(0, availableTrans.Count);

        Segment segment = GetSegment(id, true);

        segment.transform.position = spawnPoint;
        TerrainBlock tempTerrain = GetTerrain();
        tempTerrain.transform.position = spawnPoint;

        spawnPoint.z += segment.length;
        activeSegCount++;
        spawnedSegsCount++;
        segment.SpawnWith(tempTerrain);
    }

    private Segment GetSegment(int segmentId, bool transition)
    {
        Segment segment = activeSegs.Find(seg => seg.segmentId == segmentId && seg.transition == transition && !seg.gameObject.activeSelf);

        if (segment == null)
        {
            GameObject go = null;
            if (transition)
            {
                go = availableTrans[segmentId].gameObject;
            }
            else
            {
                go = availableSegs[segmentId].gameObject;
            }
            go = Instantiate(go as GameObject);
            segment = go.GetComponent<Segment>();

            segment.segmentId = segmentId;
            segment.transition = transition;

            activeSegs.Insert(0, segment);
        }
        else
        {
            activeSegs.Remove(segment);
            activeSegs.Insert(0, segment);
        }

        return segment;
    }

    public TerrainBlock GetTerrain()
    {
        //reset for prototyping purposes
        //in final game, race would end
        GameObject go;
        int terrainIndex = 0;
        if(spawnedSegsCount < TRANSITION_COUNT)
        {
            terrainIndex = 0; // Forest
        }
        else if (spawnedSegsCount > TRANSITION_COUNT)
        {
            terrainIndex = 2; // Beach
        }
        else // == TRANSTITION_COUNT
        {
            terrainIndex = 1; // Transition block
        }

        go = terrainList[terrainIndex].gameObject;
        go = Instantiate(go);
        TerrainBlock terrainObj = go.GetComponent<TerrainBlock>();

        return terrainObj;
    }
}
