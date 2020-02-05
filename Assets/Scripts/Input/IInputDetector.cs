using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IInputDetector
    {
        InputDirection? DetectInputDirection();
    }

    public enum InputDirection
    {
        Left, Right, Top, Bottom
    }
}
