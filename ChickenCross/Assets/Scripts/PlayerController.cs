// References:
//  THIRD PERSON MOVEMENT in Unity by Brackeys - https://www.youtube.com/watch?v=4HpC--2iowE
//  Unity Input System: Jumping with Character Controller by Learn ICT NOW - https://www.youtube.com/watch?v=cnSqgA4OIEk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform myCamera;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private Vector3 velocity;
    private bool groundedCheck;
    private bool jumpPressed;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float gravity = -9.81f;

    private PlayerInput playerInput;
    private InputAction moveAction, sprintStartAction, sprintEndAction;

    private MovementSystem movementSystem;
    private bool isSprinting;
    private PlayerBars playerBar;
    private int energy;

    private CheckpointManager checkMng;

    private void Awake()
    {
        movementSystem = new MovementSystem();
        movementSystem.Movement.Jump.performed += x => OnJump();
        movementSystem.Movement.SprintStart.performed += x => SprintPressed();
        movementSystem.Movement.SprintFinish.performed += x => SprintReleased();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = movementSystem.FindAction("Move"); ;
        playerBar = GetComponent<PlayerBars>();
        checkMng = GameObject.FindGameObjectWithTag("CheckMNG").GetComponent<CheckpointManager>();
        controller.enabled = false;
        controller.transform.position = checkMng.lastCheckpointPos;
        controller.enabled = true;
    }

    void Update()
    {
        JumpPlayer();
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 dirValue = moveAction.ReadValue<Vector2>();
        Vector3 direction = new Vector3(dirValue.x, 0, dirValue.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + myCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            energy = playerBar.currentEnergy;
            if (isSprinting && energy > 0)
            {
                animator.SetBool("running", true);
                controller.Move((speed*2) * Time.deltaTime * moveDir.normalized);
                playerBar.ChangeEnergy(-3);
            }
            else
            {
                animator.SetBool("running", false);
                animator.SetBool("walking", true);
                controller.Move(speed * Time.deltaTime * moveDir.normalized);
            }
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    private void JumpPlayer()
    {
        groundedCheck = controller.isGrounded;
        if (groundedCheck)
        {
            velocity.y = 0f;
            animator.SetBool("jumped", false);
        }

        if (jumpPressed && groundedCheck)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -1f * gravity);
            animator.SetBool("jumped", true);
            jumpPressed = false;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnJump()
    {
        if (controller.velocity.y == 0)
        {
            jumpPressed = true;
        }
    }

    private void SprintPressed()
    {
        isSprinting = true;
    }
    private void SprintReleased()
    {
        isSprinting = false;
    }

    private void OnEnable()
    {
        movementSystem.Enable();
    }
    private void OnDisable()
    {
        movementSystem.Disable();
    }
}
