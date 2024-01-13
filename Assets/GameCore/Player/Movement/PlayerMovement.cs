using Assets.GameCore.ScriptableObjects;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSettings _settings;
    [SerializeField] private Animator _animController;
    private bool _isGrounded, _movementThisFrame, _jumpInput;
    private Vector3 _moveDirection, _moveVelocity;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Disable rigidbody rotation
    }

    void Update()
    {
        // Check if the player is on the ground
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool jumpInput = Input.GetButtonDown("Jump");

        if (horizontalInput != 0 || verticalInput != 0 || jumpInput)
        {
            _movementThisFrame = true;
            _animController.SetBool("Walking", true);
            _moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            _moveVelocity = _moveDirection * _settings.MoveSpeed;
            _jumpInput = jumpInput;
        }
        else
        {
            _animController.SetBool("Walking", false);
        }

        //float horizontalSpeed = 2.0F;
        float h = _settings.RotationSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }

    private void FixedUpdate()
    {
        if (_movementThisFrame == false)
            return;

        _movementThisFrame = false;

        // Move the player using Rigidbody.MovePosition
        rb.MovePosition(rb.position + _moveVelocity * Time.fixedDeltaTime);

        // Jumping
        if (_jumpInput && _isGrounded)
        {
            rb.AddForce(Vector3.up * _settings.JumpForce, ForceMode.Impulse);
            _animController.SetTrigger("Jump");
        }
            
    }
}
