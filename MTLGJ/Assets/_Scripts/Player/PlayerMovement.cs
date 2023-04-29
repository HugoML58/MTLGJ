using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpHeight;

    [SerializeField] float gravity = -9.81f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] CharacterController controller;
    [SerializeField] Transform playerCamera;
    [SerializeField] InputsListener inputs;
    [SerializeField] bool lockCursor;

    Vector3 _velocity;
    float _currentSpeed;
    bool _isGrounded;

    float _xRotation;
    float _mouseXSensitivity = 0.6f;
    float _mouseYSensitivity = 1.2f;

    private void Start()
    {
        if(lockCursor) Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        CheckGrounded();
        ApplyGravity();
    }

    private void LateUpdate()
    {
        Rotate();
    }

    private void CheckGrounded()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, groundLayer);
    }

    private void ApplyGravity()
    {
        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }
    }

    private void Move()
    {
        Vector3 direction = (transform.right * inputs.Movement.x) + (transform.forward * inputs.Movement.y);
        
        if (inputs.Sprint) _currentSpeed = runSpeed;
        else _currentSpeed = walkSpeed;
        controller.Move(direction * _currentSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        float mouseX = inputs.CameraView.x * _mouseXSensitivity;
        float mouseY = inputs.CameraView.y * _mouseYSensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
