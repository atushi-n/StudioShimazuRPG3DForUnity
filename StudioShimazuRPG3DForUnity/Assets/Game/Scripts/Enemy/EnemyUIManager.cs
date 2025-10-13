using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : MonoBehaviour
{
    public Slider HpSlider;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        HpSlider.maxValue = EnemyManager.maxHp;
    }

    public void UpdateHP(int hp)
    {
        //DOValueの解説: 0.5秒かけてhp値までスライダーを動かす
        HpSlider.DOValue(hp, 0.5f);
    }
}
