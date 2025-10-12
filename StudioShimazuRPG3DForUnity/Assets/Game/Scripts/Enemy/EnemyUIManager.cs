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
        HpSlider.value = hp;
    }
}
