using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static float DEFAULT_MOVE_SPEED = 5f;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private float _horizontal;
    private float _vertical;
    public float MoveSpeed { get; set; } = DEFAULT_MOVE_SPEED;
    public Collider WeaponCollider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        WeaponCollider.enabled = false;
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

    /// <summary>
    /// 武器の判定を無効にする
    /// </summary>
    public void HideColliderWeapon()
    {
        WeaponCollider.enabled = false;
    }

    /// <summary>
    /// 武器の判定を有効にする
    /// </summary>
    public void ShowColliderWeapon()
    {
        WeaponCollider.enabled = true;
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
    private void OnTriggerEnter(Collider other)
    {
        //ダメージを与えるものにぶつかったら
        var damager = other.GetComponent<Damager>();

        if (damager != null)
        {
            Debug.Log("Playerはダメージを受けた");
            _animator.SetTrigger("Hurt");
        }
    }
}