using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CharacterMoveSetting : MonoBehaviour
{
    public CharacterController _controller;
    public CharacterInput _input;
    public Vector3 moveDirection = Vector3.zero;

    [SerializeField] float gravity = 9.81f;
    [SerializeField] public float JumpSpeed = 5.5f;

    [SerializeField] private float _currentVelocity;
    [SerializeField] public float speed;
    public float smoothTime = 0.1f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<CharacterInput>();
    }

    private void Update()
    {
        MoveMove();
        JumpJump();
    }

    private void MoveMove()
    {
        Vector3 direction = new Vector3(_input.MoveInput.x, 0, _input.MoveInput.y).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            Vector3 currentMoveDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
            _controller.Move(currentMoveDirection * speed * Time.deltaTime);
        }
    }

    void JumpJump()
    {
        //점프키 입력 확인
        if (_input.Jump == true)
        {
            moveDirection.y = JumpSpeed;
        }

        //중력 적용
        moveDirection.y = moveDirection.y - gravity * Time.deltaTime;

        //이동 실시
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        _controller.Move(globalDirection * Time.deltaTime);
        _input.Jump = false;
    }
}
