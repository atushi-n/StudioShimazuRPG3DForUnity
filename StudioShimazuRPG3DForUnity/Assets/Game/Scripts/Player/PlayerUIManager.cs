using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Slider HpSlider;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        HpSlider.maxValue = PlayerManager.maxHp;
    }

    public void UpdateHP(int hp)
    {
        HpSlider.DOValue(hp, 0.5f);
    }
}
