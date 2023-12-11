using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private TextMeshProUGUI textArmor;
    [SerializeField] private TextMeshProUGUI textMana;

    private void OnArmorChanged(int armor)
    {
        textArmor.text = armor.ToString();
    }

    private void OnManaChanged(int mana, int startMana)
    {
        textMana.text = $"{mana}/{startMana}";
    }

    private void OnHealthChanged(float hp, int currentHP, int startHP)
    {
        healthBar.fillAmount = hp;
        textHP.text = $"{currentHP}/{startHP}";
    }
}
