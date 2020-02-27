using InputDetection;
using UnityEngine;

public class WASDKeysDetector : MonoBehaviour, InputDetector
{
    public InputAction? DetectInput()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            return InputAction.Up;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            return InputAction.Down;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            return InputAction.Right;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            return InputAction.Left;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            return InputAction.Item;
        }
        else
            return null;
    }
}
