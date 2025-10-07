using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static float DEFAULT_MOVE_SPEED = 5f;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private float _horizontal;
    private float _vertical;
    public float MoveSpeed { get; set; } = DEFAULT_MOVE_SPEED;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // キーボード入力を受け取る

        //移動入力
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        //攻撃入力
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Attack");
        }


    }

    private void FixedUpdate()
    {
        //向きの変更
        Vector3 direction = transform.position + new Vector3(_horizontal, 0, _vertical);
        transform.LookAt(direction);

        //移動
        _rigidbody.linearVelocity = new Vector3(_horizontal, 0, _vertical) * MoveSpeed;
        _animator.SetFloat("MoveSpeed", _rigidbody.linearVelocity.magnitude);
    }
}