using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    [SerializeField] float gravity = -9.81f;
    [SerializeField] float climbSpeed;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] CharacterController controller;
    [SerializeField] Transform playerCamera;
    [SerializeField] InputsListener inputs;
    [SerializeField] bool lockCursor;

    Vector3 _direction;
    Vector3 _velocity;
    float _currentSpeed;
    bool _isGrounded;
    bool _isClimbingLadder;
    Ladder _currentLadder;

    float _xRotation;
    float _xSensitivity;
    float _ySensitivity;

    private void Start()
    {
        if(lockCursor) Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        ClimbLadder();
        CheckGrounded();
        ApplyGravity();
    }

    private void ClimbLadder()
    {
        if(_isClimbingLadder)
        {
            _direction = Vector3.zero;

            if(inputs.Movement.y > 0)
            {
                _velocity.y = climbSpeed * Time.deltaTime;
            }
            else if (inputs.Movement.y < 0)
            {
                _velocity.y = -climbSpeed * Time.deltaTime;
            }
            else
            {
                _velocity.y = 0;
            }

            if (groundCheck.position.y <= _currentLadder.LadderBottom.position.y && inputs.Movement.y < 0) DismountLadder();
        }
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
        if(!_isClimbingLadder)
        {
            _velocity.y += gravity * Time.deltaTime;
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = 0f;
            }
        }

        controller.Move(_velocity);
    }

    private void Move()
    {
        if(!_isClimbingLadder)
        {
            _direction = (transform.right * inputs.Movement.x) + (transform.forward * inputs.Movement.y);

            if (inputs.Sprint) _currentSpeed = runSpeed;
            else _currentSpeed = walkSpeed;
        }
        
        controller.Move(_direction * _currentSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        float mouseX = inputs.CameraView.x * _xSensitivity;
        float mouseY = inputs.CameraView.y * _ySensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void DismountLadder()
    {
        _currentLadder = null;
        _isClimbingLadder = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ladder ladder))
        {   
            _currentLadder = ladder;
            _isClimbingLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Ladder ladder))
        {
            DismountLadder();
        }
    }

    private void UpdateSensitivity(float x, float y)
    {
        _xSensitivity = x;
        _ySensitivity = y;
    }

    private void OnEnable()
    {
        InputsListener.OnKeyboardSelected += UpdateSensitivity;
        InputsListener.OnControllerSelected += UpdateSensitivity;
    }
}
