using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // Animation Triggers
    public static readonly string animationJump = "Jump";
    public static readonly string animationSlide = "Slide";
    public static readonly string animationGrounded = "Grounded";
    public static readonly string animationRunning = "Running";

    // Lanes
    public static readonly int laneCount = 3;
    public static readonly float laneWidth = 2;

    //Tags
    public static readonly string tagPlayer = "Player";

    //Offsets
    public static readonly Vector3 cameraPosition = new Vector3(0f, 2.18f, -3f);
    public static readonly Vector3 cameraRotation = new Vector3(17.29f, 0f, 0f);
    public static readonly Vector3 blessingPosition = new Vector3(0f, 2.18f, 0f);
}
