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
    public PlayerUIManager playerUIManager;
    public GameObject gameOverText;
    public Transform targetEnemy;

    public static int maxHp = 100;
    int hp = maxHp;

    public static int maxStamina = 100;
    int stamina = maxStamina;

    bool isDie;
    private float _timer;

    private void Start()
    {
        isDie = false;
        hp = maxHp;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        WeaponCollider.enabled = false;
    }

    private void Update()
    {
        if (isDie)
            return;

        _timer += Time.deltaTime;

        if (_timer >= 0.5f)
        {
            _timer = 0f;
            //0.5秒ごとにスタミナ回復
            RecoverStamina();
        }

        // キーボード入力を受け取る

        //移動入力
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        //攻撃入力
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    //スタミナ回復
    private void RecoverStamina()
    {
        if (stamina >= maxStamina)
            return;

        stamina += 2;
        playerUIManager.UpdateStamina(stamina);
    }

    private void Attack()
    {
        if (stamina >= 30)
        {
            stamina -= 30;
            playerUIManager.UpdateStamina(stamina);
            LookAtTarget();
            _animator.SetTrigger("Attack");
        }
    }

    private void LookAtTarget()
    {
        if (targetEnemy == null)
            return;

        //自分と敵の距離
        float distance = Vector3.Distance(transform.position, targetEnemy.position);
        if (distance < 2f)
            transform.LookAt(targetEnemy);

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
        if (isDie)
            return;

        //向きの変更
        Vector3 direction = transform.position + new Vector3(_horizontal, 0, _vertical);
        transform.LookAt(direction);

        //移動
        _rigidbody.linearVelocity = new Vector3(_horizontal, 0, _vertical) * MoveSpeed;
        _animator.SetFloat("MoveSpeed", _rigidbody.linearVelocity.magnitude);
    }

    void Damage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            _animator.SetTrigger("Die");
            isDie = true;
            gameOverText.SetActive(true);
        }
        playerUIManager.UpdateHP(hp);
        Debug.Log("Playerの残りHP:" + hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDie)
            return;

        //ダメージを与えるものにぶつかったら
        var damager = other.GetComponent<Damager>();

        if (damager != null)
        {
            Debug.Log("Playerはダメージを受けた");
            _animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}