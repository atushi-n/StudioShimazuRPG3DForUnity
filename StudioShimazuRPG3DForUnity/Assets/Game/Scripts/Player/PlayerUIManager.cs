using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Slider HpSlider;
    public Slider StaminaSlider;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        HpSlider.maxValue = PlayerManager.maxHp;
        HpSlider.value = PlayerManager.maxHp;
        HpSlider.maxValue = PlayerManager.maxStamina;
        StaminaSlider.value = PlayerManager.maxStamina;
    }

    public void UpdateHP(int hp)
    {
        HpSlider.DOValue(hp, 0.5f);
    }

    public void UpdateStamina(int stamina)
    {
        StaminaSlider.DOValue(stamina, 0.5f);
    }
}
