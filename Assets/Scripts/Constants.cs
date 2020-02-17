using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // Animation Triggers
    public static readonly string animationJump = "Jump";
    public static readonly string animationSlide = "Slide";
    public static readonly string animationGrounded = "Grounded";

    // Lanes
    public static readonly int laneCount = 3;
    public static readonly float laneWidth = 2;

    //Players
    //public static readonly int maxPlayers = 2;
    public static readonly int maxCoins = 20;
    public static readonly int coinLoss = 5;
    public static readonly float projectileLifetime = 5f;
}
