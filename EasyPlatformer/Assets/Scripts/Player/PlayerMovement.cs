using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;

    private PlayerAnimator _animator;
    private Rigidbody2D _rigidbody;
    private float _movement;
    private float _groundRaycast = 0.05f;
    private float _minSpeed = 0;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump(_jumpForce);
        Movement();
    }

    private void Movement()
    {
        _movement = Input.GetAxis("Horizontal");

        while (_movement != _minSpeed)
        {
            _animator.RunEnable();
            transform.position += new Vector3(_movement, 0, 0) * _speed * Time.deltaTime;

            return;
        }

        _animator.RunDisable();
    }

    private void Jump(float jumpForce)
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y) < _groundRaycast)
        {
            _animator.JumpEnable();
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            return;
        }

        _animator.JumpDisable();
    }
}
