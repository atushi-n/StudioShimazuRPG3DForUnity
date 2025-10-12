using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Slider HpSlider;

    public void UpdateHP(int hp)
    {
        HpSlider.value = hp;
    }
}
