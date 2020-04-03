using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    private const int CONTINUOUS_SEGS_MAX = 5;
    private const float DEFAULT_SEGMENT_LENGTH = 22.5f;
    private const int MAX_SPAWN_DISTANCE = 130;
    private const int DESPAWN_BUFFER = 30;
    private const int TERRAIN_LENGTH = 6;
    private const int MAX = 10;


    private int activeSegCount;
    private int continuousSegCount;
    private int spawnedSegsCount;

    private int segSpawnLimit;
    private int firstTransition;
    private int secondTransition;

    private Vector3 spawnPoint;

    public List<Segment> availableSegs = new List<Segment>();
    public List<Segment> availableTrans = new List<Segment>();
    private List<Segment> activeSegs = new List<Segment>();

    public List<TerrainBlock> transitionTerrains = new List<TerrainBlock>();
    public List<TerrainBlock> volcanoTerrains = new List<TerrainBlock>();
    public List<TerrainBlock> jungleTerrains = new List<TerrainBlock>();
    public List<TerrainBlock> beachTerrains = new List<TerrainBlock>();




    public void Setup(Vector3 startPosition, int segmentCount) {
        spawnPoint = startPosition;
        segSpawnLimit = segmentCount;
        firstTransition = segmentCount / 3;
        secondTransition = (segmentCount * 2) / 3;
    }

    public void UpdateSegments(Vector3 playerPosition) {
        if (spawnedSegsCount < segSpawnLimit)
        {
            SpawnSegmentsAhead(playerPosition);
        }
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
            SpawnTransition(false);
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
                SpawnTransition(true);
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

    private void SpawnTransition(bool spawnItems)
    {
        int id = spawnItems ? 1 : 0;

        Segment segment = GetSegment(id, true);

        segment.transform.position = spawnPoint;
        TerrainBlock tempTerrain = GetTerrain();
        tempTerrain.transform.position = spawnPoint;

        spawnPoint.z += DEFAULT_SEGMENT_LENGTH;
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
        GameObject go;
        int terrainIndex = 0;
        if(spawnedSegsCount < firstTransition)
        {
            terrainIndex = Random.Range(0, volcanoTerrains.Count); // Volcano
            go = volcanoTerrains[terrainIndex].gameObject;
        }
        else if (spawnedSegsCount == firstTransition)
        {
            go = transitionTerrains[0].gameObject; // Volcano to Jungle
        }
        else if (spawnedSegsCount < secondTransition)
        {
            terrainIndex = Random.Range(0, jungleTerrains.Count); // Jungle
            go = jungleTerrains[terrainIndex].gameObject;
        }
        else if (spawnedSegsCount == secondTransition)
        {
            go = transitionTerrains[1].gameObject; // Volcano to Jungle
        }
        else
        {
            terrainIndex = Random.Range(0, beachTerrains.Count); // Beach
            go = beachTerrains[terrainIndex].gameObject;
        }


        go = Instantiate(go);
        TerrainBlock terrainObj = go.GetComponent<TerrainBlock>();

        return terrainObj;
    }
}
