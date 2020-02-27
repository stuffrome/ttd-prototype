using System;
using System.Collections.Generic;

namespace InputDetection
{
    public interface InputDetector
    {
        InputAction? DetectInput();
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
