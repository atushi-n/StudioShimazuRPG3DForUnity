using UnityEngine;

public class DogAttackBehaviour : StateMachineBehaviour
{
    //遊びで「攻撃アニメーション中はy方向に上昇し、アニメーション終了時に元の位置に戻る」ようにしてみる
    private Vector3 _startPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //日本語訳(AI) : 状態遷移が開始され、ステートマシンがこの状態を評価し始めるときに呼び出されます
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("On State Enter");
        // _startPosition = animator.transform.position;

        //メモ: コンポーネントを取得したいときは以下が実現例の一つ
        //DogManager dogManager = animator.GetComponent<DogManager>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //日本語訳(AI) : OnStateEnter と OnStateExit コールバックの間の各 Update フレームで呼び出されます
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("On State Update");
        // animator.transform.position += new Vector3(0, 0.01f, 0);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //日本語訳(AI) : 遷移が終了し、ステートマシンがこの状態の評価を終了するときに呼び出されます
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("On State Exit");
        // animator.transform.position = _startPosition;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //日本語訳(AI) : Animator.OnAnimatorMove() の直後に呼び出されます
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //日本語訳(AI) : Animator.OnAnimatorIK() の直後に呼び出されます
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
