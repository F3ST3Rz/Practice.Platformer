using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);


    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _multiplierMoveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] float _groundCheckerRange;
    [SerializeField] LayerMask _groundMask;

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);
        float distance = direction * _moveSpeed * Time.deltaTime;
        Flip(direction);

        if (Input.GetKey(KeyCode.LeftShift))
            distance *= _multiplierMoveSpeed;

        _animator.SetFloat(Speed, Mathf.Abs(distance));
        transform.Translate(distance * Vector2.right);
    }

    private void Jump()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRange, _groundMask);

        if (groundCollider && Input.GetKeyDown(KeyCode.Space))
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }

    private void Flip(float direction)
    {
        transform.localScale = new Vector3((direction >= 0) ? 1 : -1, 1, 1);
    }
}
