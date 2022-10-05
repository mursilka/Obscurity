using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Obscuity
{
    public class EnemyBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TextMeshProUGUI textHP;
        [SerializeField] private TextMeshProUGUI textArmor;

        private EnemyController _enemy;
        private Camera _camera;

        private void Awake()
        {
            _enemy = FindObjectOfType<EnemyController>();
            LookAtCamera();
            _enemy.OnHealthChangedEnemy += OnHealthChanged;
            textHP.text = $"{_enemy.Hp}/{_enemy.Hp}";
            _enemy.OnArmor += OnArmorChanged;
        }

        private void OnArmorChanged(int armor)
        {
            textArmor.text = armor.ToString();
        }

        private void OnDestroy()
        {
            _enemy.OnHealthChangedEnemy -= OnHealthChanged;
            _enemy.OnArmor -= OnArmorChanged;
        }

        private void OnHealthChanged(float hp, int currentHP, int startHP)
        {
            healthBar.fillAmount = hp;
            textHP.text = $"{currentHP}/{startHP}";
        }

        private void LookAtCamera()
        {
            _camera = FindObjectOfType<Camera>();
            transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
            transform.Rotate(0, 180, 0);
        }
    }
}