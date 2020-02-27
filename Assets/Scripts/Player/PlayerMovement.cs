using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputDetection;

public class PlayerMovement : MonoBehaviour
{
    // Internal constants
    private const float ROTATION_SPEED = 0.5f;
    private const float GROUNDING_VELOCITY = -0.1f;

    // These fields are serialized for testing.
    // NOTE: Serialization can be removed for prod
    [SerializeField]
    private float jump = 5f;
    [SerializeField]
    private float gravity = 12f;
    [SerializeField]
    private float speed = 10f;

    // Components
    private CharacterController controller;
    private InputDetector inputDetector;
    private Animator animator;

    private LaneTracker laneTracker;
    private float verticalVelocity;
    private Vector3 defaultPosition;


    private void Start()
    {
        defaultPosition = transform.position;
        laneTracker = new LaneTracker(Constants.laneCount);

        controller = GetComponent<CharacterController>();
        inputDetector = GetComponent<InputDetector>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        DetermineMovement();
        MovePlayer();
    }

    private void DetermineMovement()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = GROUNDING_VELOCITY;
            animator.SetBool(Constants.animationGrounded, true);

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
                        verticalVelocity = jump;
                        animator.SetTrigger(Constants.animationJump);
                    break;

                    case InputDirection.Down:
                        animator.SetTrigger(Constants.animationSlide);
                    break;
                }
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            animator.SetBool(Constants.animationGrounded, false);
        }
    }

    private void MovePlayer()
    {
        // Calc target pos
        Vector3 targetPosition = Vector3.zero;
        targetPosition.x = defaultPosition.x + laneTracker.lane * Constants.laneWidth;

        // Calc delta to target pos
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition.x - transform.position.x) * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        // Move player to target pos
        controller.Move(moveVector * Time.deltaTime);

        // Rotate player in dir of target pos
        Vector3 direction = controller.velocity;
        if (direction != Vector3.zero)
        {
            direction.y = 0;
            transform.forward =
                Vector3.Lerp(transform.forward, direction, ROTATION_SPEED);
        }
    }
}
