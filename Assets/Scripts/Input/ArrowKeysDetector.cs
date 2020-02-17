using InputDetection;
using UnityEngine;

public class ArrowKeysDetector : MonoBehaviour, InputDetector
{
    public InputAction? DetectInput()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
            return InputAction.Up;
        else if (Input.GetKeyUp(KeyCode.DownArrow))
            return InputAction.Down;
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            return InputAction.Right;
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
            return InputAction.Left;
        else if (Input.GetKeyUp(KeyCode.Return))
            return InputAction.Ability;
        else
            return null;
    }
}