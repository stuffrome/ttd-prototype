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
    private float jump = 10f;
    [SerializeField]
    private float gravity = 38f;
    [SerializeField]
    private float baseSpeed = 8.5f;
    private float speedMultiplier = 1.0f;
    private bool isReverse = false;

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

            InputAction? inputAction = inputDetector.DetectInput();
            if (inputAction.HasValue)
            {
                if(isReverse){
                    switch (inputAction.Value)
                    {
                        case InputAction.Left:
                            inputAction = InputAction.Right;
                        break;

                        case InputAction.Right:
                            inputAction = InputAction.Left;
                        break;

                        case InputAction.Up:
                            inputAction = InputAction.Down;
                        break;

                        case InputAction.Down:
                            inputAction = InputAction.Up;
                        break;
                    }
                }

                switch (inputAction.Value)
                {
                    case InputAction.Left:
                        laneTracker.MoveLeft();
                    break;

                    case InputAction.Right:
                        laneTracker.MoveRight();
                    break;

                    case InputAction.Up:
                        verticalVelocity = jump;
                        animator.SetTrigger(Constants.animationJump);
                    break;

                    case InputAction.Down:
                        animator.SetTrigger(Constants.animationSlide);
                    break;

                    default:
                    break;
                }
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            animator.SetBool(Constants.animationGrounded, false);

            InputAction? inputAction = inputDetector.DetectInput();
            if (inputAction.HasValue)
            {
                if(isReverse){
                    switch (inputAction.Value)
                    {
                        case InputAction.Left:
                            inputAction = InputAction.Right;
                        break;

                        case InputAction.Right:
                            inputAction = InputAction.Left;
                        break;

                        case InputAction.Up:
                            // No double jump
                        break;

                        case InputAction.Down:
                            inputAction = InputAction.Up;
                        break;
                    }
                }

                switch (inputAction.Value)
                {
                    case InputAction.Left:
                        laneTracker.MoveLeft();
                    break;

                    case InputAction.Right:
                        laneTracker.MoveRight();
                    break;

                    case InputAction.Up:
                        // No double jump
                    break;

                    case InputAction.Down:
                        // verticalVelocity *= 2;
                        animator.SetTrigger(Constants.animationSlide);
                    break;

                    default:
                    break;
                }
            }
        }
    }

    private void MovePlayer()
    {
        // Calc target pos
        Vector3 targetPosition = Vector3.zero;
        targetPosition.x = defaultPosition.x + laneTracker.lane * Constants.laneWidth;

        // Calc delta to target pos
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition.x - transform.position.x) * baseSpeed; // horizontal
        moveVector.y = verticalVelocity; // vertical
        moveVector.z = baseSpeed * speedMultiplier; // forward

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

        // Change player collider
        if (animator.GetBool(Constants.animationSlide))
        {
            StartSlide();
        }
    }

    private void StartSlide()
    {
        controller.height /= 2;
        controller.center = new Vector3(controller.center.x, controller.center.y/2, controller.center.z);
        Invoke("EndSlide", 0.5f);
    }

    private void EndSlide()
    {
        controller.height *= 2;
        controller.center = new Vector3(controller.center.x, controller.center.y*2, controller.center.z);
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    public int GetLane()
    {
        return laneTracker.lane;
    }

    public void Stumble()
    {
        animator.SetTrigger(Constants.animationSlide);
    }

    public void Reverse(){
        isReverse = true;        
    }

    public void UnReverse(){
        isReverse = false;
    }

    public void SetMoving(bool moving)
    {
        if (moving)
        {
            animator.SetBool(Constants.animationRunning, true);
            if (speedMultiplier == 0f)
            {
                speedMultiplier = 1f;
            }
        }
        else
        {
            animator.SetBool(Constants.animationRunning, false);
            speedMultiplier = 0f;
        }
    }
}
