using InputDetection;
using UnityEngine;

public class WASDKeysDetector : MonoBehaviour, InputDetector
{
    public InputDirection? DetectInputDirection()
    {
        if (Input.GetKeyUp(KeyCode.W))
            return InputDirection.Up;
        else if (Input.GetKeyUp(KeyCode.S))
            return InputDirection.Down;
        else if (Input.GetKeyUp(KeyCode.D))
            return InputDirection.Right;
        else if (Input.GetKeyUp(KeyCode.A))
            return InputDirection.Left;
        else
            return null;
    }
}
