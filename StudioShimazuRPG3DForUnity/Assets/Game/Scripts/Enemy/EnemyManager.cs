using UnityEngine;
using UnityEngine.AI;


/*
Enemyのアニメーション: Playerとの距離に応じてアニメーションを切り替える
- Idle: 遠い
- Run: やや近い
- Attack: 近い
*/


public class EnemyManager : MonoBehaviour
{
    public Transform _target;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = _target.position;
    }

    private void Update()
    {
        _navMeshAgent.destination = _target.position;
    }
}
