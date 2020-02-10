using System;
using System.Collections.Generic;

namespace InputDetection
{
    public interface InputDetector
    {
        InputDirection? DetectInputDirection();
    }

    public enum InputDirection
    {
        Left, Right, Up, Down
    }
}
