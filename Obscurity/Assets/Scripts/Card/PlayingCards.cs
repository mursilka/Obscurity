using System;
using TMPro;
using UnityEngine;

namespace Obscuity
{
    public class PlayingCards : MonoBehaviour
    {
        private const string ENEMY = "Enemy";
        
        [SerializeField] private TextMeshPro manaCostText;
        [SerializeField] private TextMeshPro descriptionText;
        [SerializeField] private SpriteRenderer sprite;

        private PlayerController _player;
        private EnemyController _enemy;
        private LayerMask _layerMaskEnemy;

        public int _damage;
        public int _hp;
        public int _armor;
        public int _manaCost;

        private void Awake()
        {
            _layerMaskEnemy = LayerMask.GetMask(ENEMY);
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
            
            Debug.Log(descriptionText.text);
            Debug.Log(transform.position);
        }

        private void OnDestroy()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layerMaskEnemy))
            {
                Debug.Log(transform.position);
                if (hit.collider.gameObject.GetComponent<EnemyController>())
                {
                    if(_damage>0) hit.collider.gameObject.GetComponent<EnemyController>().Health(_damage); 
                    if(_armor>0)_player.Armor(_armor);
                }
                
            }
            
           
        }

    }
}