using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for tracking lane position and boundaries
// NOTE: lane count SHOULD always be ODD for a symmetrical view
public class LaneTracker
{
    // e.g. with 3 lanes: -1 = Left, 0 = Middle, 1 = Right
    private readonly int LEFTMOST_LANE;
    private readonly int RIGHTMOST_LANE;

    public int lane { get; private set; }

    public LaneTracker(int laneCount)
    {
        // Default to middle lane, always 0
        lane = 0;

        LEFTMOST_LANE = -laneCount / 2;
        RIGHTMOST_LANE = laneCount / 2;
    }

    public void MoveLeft()
    {
        lane--;

        // Boundary check
        if (lane < LEFTMOST_LANE)
        {
            lane = LEFTMOST_LANE;
        }
    }

    public void MoveRight()
    {
        lane++;

        // Boundary check
        if (lane > RIGHTMOST_LANE)
        {
            lane = RIGHTMOST_LANE;
        }
    }
}
