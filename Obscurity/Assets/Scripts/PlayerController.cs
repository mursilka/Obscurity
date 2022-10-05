using System;
using Obscuity.Ads;
using UnityEngine;

namespace Obscuity
{
    public class PlayerController : MonoBehaviour
    {
        private const string PLAYING_CARD = "PlayingCard";
        private const string ENEMY = "Enemy";
        
        [SerializeField] private int startHp;
        [SerializeField] private int startArmor;
        [SerializeField] private int startMana;

        private GameManager _gameManager;
        private CardDeck _cardDeck;
        private PlayingCards _holdCard;
        private Camera _mainCamera;
        private LayerMask _layerMask;
        private LayerMask _layerMaskEnemy;

        private Vector3 _offset;

        private int _damage;
        private int _currentArmor;
        private int _currentHp;
        private int _currentMana;

        private AdsInitializer _ads;

        public Action<float,int,int> OnHealthChanged;
        public Action OnDead;
        public Action<int,int> OnMana;
        public Action<int> OnArmor;
        
        
        public int StartHp => startHp;

        public int StartMana => startMana;

        public int StartArmor => startArmor;

        private void Awake()
        {

            _mainCamera = Camera.main;
            _layerMask = LayerMask.GetMask(PLAYING_CARD);
            _layerMaskEnemy = LayerMask.GetMask(ENEMY);
            _gameManager = FindObjectOfType<GameManager>();
            _ads = FindObjectOfType<AdsInitializer>();
        }

        private void Start()
        {
            _gameManager.OnStartGame += StartHpChanged;
            _gameManager.OnHandChanged += ResetMana;
            _ads.OnButtonHealthChanged += HalfHp;
            OnArmor?.Invoke(_currentArmor);
        }

        private void StartHpChanged()
        {
            _currentHp = startHp;
            float _currentHealthAsPercantage = (float)_currentHp / startHp;
            OnHealthChanged?.Invoke(_currentHealthAsPercantage, _currentHp, startHp);
            _currentArmor = startArmor;
            OnArmor?.Invoke(_currentArmor);
            _currentMana = startMana;
            OnMana?.Invoke(_currentMana,startMana);
        }


        private void ResetMana()
        {
            _currentMana = startMana;
            OnMana?.Invoke(_currentMana,startMana);
        }

        public void HealthChange(int damage)
        {
            if (_currentArmor >= damage)
            {
                _currentArmor -= damage;
                OnArmor?.Invoke(_currentArmor);
            }
            else
            {
                _currentHp = _currentHp + _currentArmor - damage;
                _currentArmor = 0;
                OnArmor?.Invoke(_currentArmor);
                if (_currentHp <=0)
                {
                    OnDead?.Invoke();
                    _currentArmor = startArmor;
                }
                else
                {
                    float _currentHealthAsPercantage = (float)_currentHp / startHp;
                    OnHealthChanged?.Invoke(_currentHealthAsPercantage, _currentHp, startHp);
                }
            }
        }
        
        private void HalfHp()
        {
            _currentHp = startHp / 2;
            float _currentHealthAsPercantage = (float)_currentHp / startHp;
            OnHealthChanged?.Invoke(_currentHealthAsPercantage, _currentHp, startHp);
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
                    if (_currentMana - card._manaCost >= 0)
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
        }

        private void ReleaseCard()
        {
            Ray ray = new Ray(_holdCard.transform.position, Vector3.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layerMaskEnemy))
            {
                _currentMana -= _holdCard._manaCost;
                OnMana?.Invoke(_currentMana,startMana);
                Destroy(_holdCard.gameObject);
            }
        }

        private void MoveCardWithMouse()
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = _holdCard.transform.position.z;
            _holdCard.transform.position = mousePosition + _offset;
        }

        public void Armor(int armor)
        {
            _currentArmor += armor;
            OnArmor?.Invoke(_currentArmor);
        }
        
        private void OnDestroy()
        {
            _gameManager.OnStartGame -= StartHpChanged;
            _gameManager.OnHandChanged -= ResetMana;
            _ads.OnButtonHealthChanged -= HalfHp;
        }
    }
}