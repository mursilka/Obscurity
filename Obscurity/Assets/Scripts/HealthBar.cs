using System;
using UnityEngine;
using UnityEngine.UI;

namespace Obscuity
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        private PlayerController _player;
        private Camera _camera;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            LookAtCamera();
            _player.OnHealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _player.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float damage)
        {
            _healthBar.fillAmount = damage;
        }

        private void LookAtCamera()
        {
            _camera = FindObjectOfType<Camera>();
            transform.LookAt(new Vector3(transform.position.x,_camera.transform.position.y,_camera.transform.position.z));
            transform.Rotate(0,180,0);
        }
    }
}