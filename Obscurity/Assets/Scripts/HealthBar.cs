using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Obscuity
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TextMeshProUGUI textHP;
        [SerializeField] private TextMeshProUGUI textArmor;
        [SerializeField] private TextMeshProUGUI textMana;

        private PlayerController _player;
        private Camera _camera;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            LookAtCamera();
            _player.OnHealthChanged += OnHealthChanged;
            _player.OnMana += OnManaChanged;
            _player.OnArmor += OnArmorChanged;
            textMana.text = $"{_player.StartMana}/{_player.StartMana}";
            textHP.text = $"{_player.StartHp}/{_player.StartHp}";
            textArmor.text = _player.StartArmor.ToString();
        }

        private void OnArmorChanged(int armor)
        {
            textArmor.text = armor.ToString();
        }

        private void OnManaChanged(int mana, int startMana)
        {
            textMana.text = $"{mana}/{startMana}";
        }

        private void OnDestroy()
        {
            _player.OnHealthChanged -= OnHealthChanged;
            _player.OnArmor -= OnArmorChanged;
        }

        private void OnHealthChanged(float hp,int currentHP, int startHP)
        {
            healthBar.fillAmount = hp;
            textHP.text = $"{currentHP}/{startHP}";
        }

        private void LookAtCamera()
        {
            _camera = FindObjectOfType<Camera>();
            transform.LookAt(new Vector3(transform.position.x,_camera.transform.position.y,_camera.transform.position.z));
            transform.Rotate(0,180,0);
        }
    }
}