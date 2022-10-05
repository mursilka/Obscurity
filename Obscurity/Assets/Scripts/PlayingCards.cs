
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

        private PlayerController _player;
        private EnemyController _enemy;

        public int _damage;
        public int _hp;
        public int _armor;
        public int _manaCost;

        private void Awake()
        {
            _enemy = FindObjectOfType<EnemyController>();
            _player = FindObjectOfType<PlayerController>();
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
            if(_damage>0)_enemy.Health(_damage);
            if(_armor>0)_player.Armor(_armor);
            
        }

    }
}