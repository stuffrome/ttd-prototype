using InputDetection;
using UnityEngine;

public class ArrowKeysDetector : MonoBehaviour, InputDetector
{
    public InputDirection? DetectInputDirection()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
            return InputDirection.Up;
        else if (Input.GetKeyUp(KeyCode.DownArrow))
            return InputDirection.Down;
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            return InputDirection.Right;
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
            return InputDirection.Left;
        else
            return null;
    }
}