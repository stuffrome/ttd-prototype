using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class CharacterSidewaysMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20f;
    private CharacterController controller;
    private Animator anim;

    private bool isChangingLane = false;
    private Vector3 locationAfterChangingLane;
    //distance character will move sideways
    private Vector3 sidewaysMovementDistance = Vector3.right * 2f;

    public float SideWaysSpeed = 5.0f;

    public float JumpSpeed = 8.0f;
    public float Speed = 6.0f;
    //Max gameobject
    public Transform CharacterGO;

    IInputDetector inputDetector = null;

    void Start()
    {
        moveDirection = transform.forward;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= Speed;

        UIManager.instance.ResetScore();
        UIManager.instance.SetStatus(Constants.statusTapToStart);

        GameManager.instance.gameState = GameState.Start;

        anim = CharacterGO.GetComponent<Animator>();
        inputDetector = GetComponent<IInputDetector>();
        controller = GetComponent<CharacterController>();
    }

    private void CheckHeight()
    {
        if (transform.position.y < -10)
    {
            GameManager.instance.Die();
        }
    }

    private void DetectJumpOrSwipeLeftRight()
    {
        var inputDirection = inputDetector.DetectInputDirection();
        if (controller.isGrounded && inputDirection.HasValue && inputDirection == InputDirection.Top && !isChangingLane)
        {
            moveDirection.y = JumpSpeed;
            anim.SetBool(Constants.animationJump, true);
        }
        else
        {
            anim.SetBool(Constants.animationJump, false);
        }
        if (controller.isGrounded && inputDirection.HasValue && !isChangingLane)
        {
            isChangingLane = true;

            if (inputDirection == InputDirection.Left)
            {
                locationAfterChangingLane = transform.position - sidewaysMovementDistance;
                moveDirection.x = -SideWaysSpeed;
            }
            else if (inputDirection == InputDirection.Right)
            {
                locationAfterChangingLane = transform.position + sidewaysMovementDistance;
                moveDirection.x = SideWaysSpeed;
            }
        }
    }

    void Update()
    {
        switch (GameManager.instance.gameState)
        {
            case GameState.Start:
                if (Input.GetMouseButtonUp(0))
                {
                    anim.SetBool(Constants.animationStarted, true);
                    var instance = GameManager.instance;
                    instance.gameState = GameState.Playing;

                    UIManager.instance.SetStatus(string.Empty);
                }
                break;
            case GameState.Playing:
                UIManager.instance.IncreaseScore(0.001f);

                CheckHeight();

                DetectJumpOrSwipeLeftRight();

                //apply gravity
                moveDirection.y -= gravity * Time.deltaTime;

                if (isChangingLane)
                {
                    if (Mathf.Abs(transform.position.x - locationAfterChangingLane.x) < 0.1f)
                    {
                        isChangingLane = false;
                        moveDirection.x = 0;
                    }
                }

                //move the player
                controller.Move(moveDirection * Time.deltaTime);

                break;
            case GameState.Dead:
                anim.SetBool(Constants.animationStarted, false);
                if (Input.GetMouseButtonUp(0))
                {
                    //restart
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            default:
                break;
        }

    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if we hit the left or right border
        if (hit.gameObject.tag == Constants.widePathBorderTag)
        {
            isChangingLane = false;
            moveDirection.x = 0;
        }
    }
}
