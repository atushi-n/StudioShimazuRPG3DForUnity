using UnityEngine;
using UnityEngine.AI;


/*
Enemyのアニメーション: Playerとの距離に応じてアニメーションを切り替える
- Idle: 遠い: 7以上 : speedを0
- Run: やや近い: 7以下 : speedを2
- Attack: 近い : 2以下 : speedを0
*/

public class EnemyManager : MonoBehaviour
{
    public Transform _target;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = _target.position;
    }

    private void Update()
    {
        _navMeshAgent.destination = _target.position;
        _animator.SetFloat("Distance", _navMeshAgent.remainingDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        //ダメージを与えるものにぶつかったら
        var damager = other.GetComponent<Damager>();

        if (damager != null)
        {
            Debug.Log("敵はダメージを受けた");
        }
    }
}
