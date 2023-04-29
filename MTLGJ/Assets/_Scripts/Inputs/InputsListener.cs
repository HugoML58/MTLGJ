using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsListener : MonoBehaviour
{
    public Vector2 Movement;
    public Vector2 CameraView;
    public bool Sprint;
    public bool Jump;
    public bool Interact;
    public bool Pause;

    bool _hasJumped = false;
    bool _hasInteracted;

    private PlayerInputActions _inputs;

    private void Awake()
    {
        _inputs = new PlayerInputActions();

        _inputs.Gameplay.Sprint.performed += ctx => OnSprint(ctx);
        _inputs.Gameplay.Sprint.canceled += ctx => SprintEnded(ctx);

        _inputs.Gameplay.Jump.performed += ctx => OnJump(ctx);

        _inputs.Gameplay.Interact.performed += ctx => OnInteract(ctx);

        _inputs.Gameplay.Pause.performed += ctx => OnPause(ctx);
    }

    private void OnSprint(InputAction.CallbackContext ctx) { Sprint = true; }

    private void SprintEnded(InputAction.CallbackContext ctx) { Sprint = false; }

    private void OnInteract(InputAction.CallbackContext ctx) { _hasInteracted = true; }

    private void OnPause(InputAction.CallbackContext ctx) { Pause = !Pause; }

    private void Update()
    {
        Movement = _inputs.Gameplay.Movement.ReadValue<Vector2>();
        CameraView = _inputs.Gameplay.View.ReadValue<Vector2>();

        Jump = false;

        if (_hasJumped)
        {
            Jump = true;
            _hasJumped = false;
        }

        Interact = false;

        if (_hasInteracted)
        {
            Interact = true;
            _hasInteracted = false;
        }
    }

    private void OnJump(InputAction.CallbackContext ctx) { _hasJumped = true; }

    private void OnEnable()
    {
        _inputs.Gameplay.Enable();
    }
    private void OnDisable()
    {
        _inputs.Gameplay.Disable();
    }
}
