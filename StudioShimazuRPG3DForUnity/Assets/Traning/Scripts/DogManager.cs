using UnityEngine;

namespace Traning
{
    public class DogManager : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            //スペースボタンが押されたら
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //攻撃に移行
                _animator.SetTrigger("Attack");
            }

            //Mキーが押されたら
            if (Input.GetKeyDown(KeyCode.M))
            {
                _animator.SetFloat("MoveSpeed", 1.0f);
            }

            //Nキーが押されたら
            if (Input.GetKeyDown(KeyCode.N))
            {
                _animator.SetFloat("MoveSpeed", 0.0f);
            }
        }

        public void AttackLog()
        {
            Debug.Log("AttackLog");
        }
    }
}