using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DinoController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float jumpSpeed = 2f;
    public InputSystem_Actions dinoActions;
    private Vector2 move;
    public Camera dinoCamera;
    private float velocity;

    void Awake()
    {
        dinoActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        dinoActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Gravity();
    }

    void Gravity()
    {
        if(!IsGrounded())
        {
            velocity += -9.81f * Time.deltaTime;
        }
        else
        {
            velocity = 0;
        }
    }

    void Movement()
    {

        Debug.Log(IsGrounded());
        move = dinoActions.Player.Move.ReadValue<Vector2>();

        Vector3 forward = dinoCamera.transform.forward;
        Vector3 right = dinoCamera.transform.right;

        right.y = 0;
        right = right.normalized;

        forward.y = 0;
        forward = forward.normalized;

        Vector3 forwardInput = forward * move.y;
        Vector3 rightInput = right * move.x;

        Vector3 moveDirection = forwardInput + rightInput + new Vector3(0, velocity, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position + transform.up * 0.25f, -transform.up, 0.3f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
