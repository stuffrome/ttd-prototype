using System;
using System.Collections.Generic;

namespace InputDetection
{
    public interface InputDetector
    {
        InputAction? DetectInputDirection();
    }

    public enum InputAction
    {
        Left,
        Right,
        Up,
        Down,
        Item
    }
}
