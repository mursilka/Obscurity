using System;
using UnityEngine;
using UnityEngine.UI;


namespace Obscuity
{
    public class PlayerController : MonoBehaviour
    {
        private const string PLAYING_CARD = "PlayingCard";
        private const string ENEMY = "Enemy";
        
        [SerializeField] private int startHp;
        [SerializeField] private int startArmor;
        
        private CardDeck _cardDeck;
        private PlayingCards _holdCard;
        private Camera _mainCamera;
        private LayerMask _layerMask;
        private LayerMask _layerMaskEnemy;

        private Vector3 _offset;

        private int _damage;
        private int _currentArmor;
        private int _currentHp;

        public Action<float> OnHealthChanged; 
        private void Awake()
        {
            _currentHp = startHp;
            _currentArmor = startArmor;
            _mainCamera = Camera.main;
            _layerMask = LayerMask.GetMask(PLAYING_CARD);
            _layerMaskEnemy = LayerMask.GetMask(ENEMY);
        }

        private void HealthChange(int damage)
        {
            _currentHp += damage;
            if (_currentHp < 0)
            {
                
            }
            else
            {
                float _currentHealthAsPercantage = (float)_currentHp / startHp;
                OnHealthChanged?.Invoke(_currentHealthAsPercantage);
            }
        }
        
        private void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                TryHoldCard();
            }

            if (Input.GetMouseButton(0) && _holdCard != null)
            {
                MoveCardWithMouse();
            }

            if (Input.GetMouseButtonUp(0) && _holdCard != null)
            {
                ReleaseCard();
            }
        }

       
        private void TryHoldCard()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layerMask))
            {
                if (hit.collider.gameObject.TryGetComponent(out PlayingCards card))
                {
                    _holdCard = card;
                    _holdCard.transform.Translate(Vector3.back * 0.5f, Space.World);
                    Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    var position = _holdCard.transform.position;
                    mousePosition.z = position.z;
                    _offset = _holdCard.transform.position - mousePosition;
                }
            }
        }

        private void ReleaseCard()
        {
            Ray ray = new Ray(_holdCard.transform.position, Vector3.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layerMaskEnemy))
            {
                Destroy(_holdCard.gameObject);
            }
        }

        private void MoveCardWithMouse()
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = _holdCard.transform.position.z;
            _holdCard.transform.position = mousePosition + _offset;
        }
    }
}