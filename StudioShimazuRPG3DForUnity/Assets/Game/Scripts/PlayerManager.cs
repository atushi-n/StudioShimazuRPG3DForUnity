using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    private float _horizontal;
    private float _vertical;
    private float _moveSpeed = 5f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // キーボード入力を受け取る
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector3(_horizontal, 0, _vertical) * _moveSpeed;
        _animator.SetFloat("MoveSpeed", _rigidbody.linearVelocity.magnitude);
    }
}