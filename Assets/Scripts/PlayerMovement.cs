using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputDetection;

public class PlayerMovement : MonoBehaviour
{
    // Position of the center lane
    private Vector3 defaultPosition;

    // These fields are serialized for testing.
    // NOTE: Serialization can be removed for prod
    [SerializeField]
    private float jump = 4f;
    [SerializeField]
    private float gravity = 12f;
    [SerializeField]
    private float speed = 10f;

    private LaneTracker laneTracker;
    private CharacterController controller;
    private InputDetector inputDetector;

    private float verticalVelocity;


    private void Start()
    {
        defaultPosition = transform.position;
        laneTracker = new LaneTracker(Constants.laneCount);

        controller = GetComponent<CharacterController>();
        inputDetector = GetComponent<InputDetector>();
    }

    private void Update()
    {
        GatherInput();
        MovePlayer();
    }

    private void GatherInput()
    {
        InputDirection? inputDirection = inputDetector.DetectInputDirection();
        if (inputDirection.HasValue)
        {
            switch (inputDirection.Value)
            {
                case InputDirection.Left:
                    laneTracker.MoveLeft();
                break;

                case InputDirection.Right:
                    laneTracker.MoveRight();
                break;

                case InputDirection.Up:
                break;

                case InputDirection.Down:
                break;
            }
        }
    }

    private void MovePlayer()
    {
        Vector3 targetPosition = Vector3.zero;
        targetPosition.x = defaultPosition.x + laneTracker.lane * Constants.laneWidth;

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition.x - transform.position.x) * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }
}
