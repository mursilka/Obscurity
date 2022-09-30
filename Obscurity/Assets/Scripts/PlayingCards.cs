
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

namespace Obscuity
{
    public class PlayingCards : MonoBehaviour
    {
        [SerializeField] private TextMeshPro manaCostText;
        [SerializeField] private TextMeshPro descriptionText;
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private EnemyController _enemy;

        public int _damage;
        public int _hp;
        public int _armor;
        public int _manaCost;

        private void Awake()
        {
            _enemy = FindObjectOfType<EnemyController>();
            
        }

        public void Initialize(CardDescription descriptionCard)
        {
            _damage = descriptionCard.Damage;
            _hp = descriptionCard.Hp;
            _armor = descriptionCard.Armor;
            _manaCost = descriptionCard.ManaCost;
            manaCostText.text = Convert.ToString(descriptionCard.ManaCost);
            descriptionText.text = Convert.ToString(descriptionCard.Description);
            sprite.sprite = descriptionCard.IkonSprite;
            
        }

        private void OnDestroy()
        {
            _enemy.Health(_damage);
        }

    }
}