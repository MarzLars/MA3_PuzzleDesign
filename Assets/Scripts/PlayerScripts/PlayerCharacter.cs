using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : MonoBehaviour, IPlayerCharacterModel
{
    public Vector2 MovementVector { get; set; }
    public bool IsGrounded { get { return _controller.isGrounded; } }

    [SerializeField] 
    private float speed;
    [SerializeField] 
    private float jumpForce;
    [SerializeField] 
    private float dampTime;
    [SerializeField]
    private float desiredRotationSpeed = 0.1f; //Speed of the players rotation
    [SerializeField]
    private float accelerationTime = 0.2f, decelerationTime = 0.1f;
    
    private Vector3 _localVelocity;
    private Vector3 _dampVelocity;
    private Vector3 _verticalVelocity;
    
    private float _rotationBlendSpeed;
    private float _maxSpeed;
   
    private bool _jump;
    private bool _isJumping;
    private bool _canJump = true;
    
    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        Vector3 xzForward = Vector3.ProjectOnPlane(forward, Vector3.up).normalized;
        Vector3 xzVelocity = Vector3.ProjectOnPlane(_controller.velocity, Vector3.up);
        Vector3 desiredVelocity = MovementVector.y * xzForward + MovementVector.x * right;

        desiredVelocity.Normalize();
        desiredVelocity *= speed;

        if (!_controller.isGrounded)
        {
            desiredVelocity = xzVelocity;
        }

        var smoothDampTime = _controller.velocity.sqrMagnitude > desiredVelocity.sqrMagnitude ? decelerationTime : accelerationTime;
        desiredVelocity = Vector3.SmoothDamp(xzVelocity, desiredVelocity, ref _dampVelocity, smoothDampTime);

        _verticalVelocity += Physics.gravity * Time.deltaTime;

        // Add rotation logic from ExampleCharacterMovement.cs
        if (_controller.isGrounded && _controller.velocity.sqrMagnitude > 0.01f)
        {
            // Rotation logic
            Vector3 horizontalMovement = new Vector3(_controller.velocity.x, 0, _controller.velocity.z);
            Quaternion targetRotation = Quaternion.LookRotation(horizontalMovement, Vector3.up);
            transform.rotation =
                Quaternion.Slerp(transform.rotation, targetRotation, desiredRotationSpeed * Time.deltaTime);
        }

        if (_controller.isGrounded)
        {
            _verticalVelocity.y = -1f;
            if (_jump)
            {
                _verticalVelocity.y = jumpForce;
            }
            _canJump = true;
        }
        _jump = false;
        _controller.Move((_verticalVelocity + desiredVelocity) * Time.deltaTime);
    }
    private void LateUpdate()
    {
        Vector3 forward = transform.forward;
        RotateTowards(forward);
        CalculateVelocity();
    }
    
    private void RotateTowards(Vector3 forward)
    {
        // Rotate towards the camera (Camera forward) if the character is moving (tip use sqrMagnitude and isGrounded)
        if (_controller.isGrounded && _controller.velocity.sqrMagnitude > 0.01f)
        {
            Vector3 horizontalForward = Vector3.ProjectOnPlane(forward, Vector3.up);

            // This line will do the rotation
            Quaternion targetRotation = Quaternion.LookRotation(horizontalForward, Vector3.up);
            // Tip, use Quaternion.Slerp to make the rotation smoother
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, desiredRotationSpeed * Time.deltaTime);
        }
    }
    private void CalculateVelocity()
    {
        // In this line we change from world coordinates to localcoordinates allowing
        //  us to have a local perspective of the movement according to where the
        //  player is looking towards. 
        // Check this out for visual explanation: https://nord.instructure.com/courses/23352/pages/velocity-in-world-vs-local-coords

        _localVelocity = transform.worldToLocalMatrix.MultiplyVector(_controller.velocity);
        _maxSpeed = speed;

        if (_localVelocity.sqrMagnitude > 0)
        {
            _maxSpeed *= Mathf.Max(Mathf.Abs(_localVelocity.normalized.z), Mathf.Abs(_localVelocity.normalized.x));
        }
    }
    
    public void Jump()
    {
        if (_controller.isGrounded && _canJump)
        {
            _jump = true;
            _canJump = false;
        }
    }
}