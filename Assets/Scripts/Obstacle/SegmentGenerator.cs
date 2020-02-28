using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    private const int MAX_SEGS = 15;
    private const int CONTINUOUS_SEGS_MAX = 5;
    private const int START_BUFFER = 30;
    private const int SEGMENT_BUFFER = 4;

    private int activeSegCount;
    private int continuousSegCount;

    private Vector3 spawnPoint;

    public List<Segment> availableSegs = new List<Segment>();
    public List<Segment> availableTrans = new List<Segment>();
    private List<Segment> activeSegs = new List<Segment>();


    public void GenerateSegments(Vector3 startPosition, int count)
    {
        spawnPoint = startPosition;
        spawnPoint.z += START_BUFFER;

        for (int i = 0; i < count; i++)
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

        segment.transform.position = spawnPoint;

        spawnPoint.z += segment.length + SEGMENT_BUFFER;
        activeSegCount++;
        segment.Spawn();
    }

    private void SpawnTransition()
    {
        int id = Random.Range(0, availableTrans.Count);

        Segment segment = GetSegment(id, true);

        segment.transform.position = spawnPoint;

        spawnPoint.z += segment.length;
        activeSegCount++;
        segment.Spawn();
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

            Instantiate(go as GameObject);
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
}
