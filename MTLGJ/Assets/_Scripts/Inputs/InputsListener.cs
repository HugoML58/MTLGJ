using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsListener : MonoBehaviour
{
    [SerializeField] float mouseXSensitivity;
    [SerializeField] float mouseYSensitivity;
    [SerializeField] float controllerXSensitivity;
    [SerializeField] float controllerYSensitivity;
    
    public Vector2 Movement;
    public Vector2 CameraView;
    public bool Sprint;
    public bool Interact;
    public bool Pause;

    bool _hasInteracted;
    bool _isController;

    PlayerInputActions _inputs;

    public static event Action<float, float> OnKeyboardSelected;
    public static event Action<float, float> OnControllerSelected;
    
    private void Awake()
    {
        _inputs = new PlayerInputActions();

        _inputs.Gameplay.Movement.performed += ctx => OnMove(ctx);
        _inputs.Gameplay.Movement.canceled += ctx => OnMove(ctx);

        _inputs.Gameplay.Sprint.performed += ctx => OnSprint(ctx);
        _inputs.Gameplay.Sprint.canceled += ctx => SprintEnded(ctx);

        _inputs.Gameplay.Interact.performed += ctx => OnInteract(ctx);

        _inputs.Pause.Pause.performed += ctx => OnPause(ctx);
    }

    private void Start()
    {
        if (!_isController) OnKeyboardSelected?.Invoke(mouseXSensitivity, mouseYSensitivity);
        else OnControllerSelected?.Invoke(controllerXSensitivity, controllerYSensitivity);
    }

    private void GetDevice(InputAction.CallbackContext ctx)
    {
        if (ctx.control.device is Keyboard || ctx.control.device is Mouse)
        {
            Debug.Log("Keyboard");
            _isController = false;
            OnKeyboardSelected?.Invoke(mouseXSensitivity, mouseYSensitivity);
        }
        else
        {
            if(!_isController)
            {
                Debug.Log("Controller");
                _isController = true;
                OnControllerSelected?.Invoke(controllerXSensitivity, controllerYSensitivity);
            }
        }
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
        GetDevice(ctx);
    }

    private void OnSprint(InputAction.CallbackContext ctx) { Sprint = true; }

    private void SprintEnded(InputAction.CallbackContext ctx) { Sprint = false; }

    private void OnInteract(InputAction.CallbackContext ctx) { _hasInteracted = true; }

    private void OnPause(InputAction.CallbackContext ctx)
    {
        GameManager.Instance.Pause();
    }

    public void ChangeInputState(bool state)
    {
        Pause = state;
        if (Pause)
        {
            _inputs.Gameplay.Disable();
        }
        else
        {
            _inputs.Gameplay.Enable();
        }
    }

    private void Update()
    {
        CameraView = _inputs.Gameplay.View.ReadValue<Vector2>();

        Interact = false;

        if (_hasInteracted)
        {
            Interact = true;
            _hasInteracted = false;
        }
    }

    private void OnEnable()
    {
        _inputs.Gameplay.Enable();
        _inputs.Pause.Enable();

        GameManager.OnGamePaused += ChangeInputState;
    }

    private void OnDisable()
    {
        _inputs.Gameplay.Disable();
        _inputs.Pause.Disable();

        GameManager.OnGamePaused -= ChangeInputState;
    }
}
