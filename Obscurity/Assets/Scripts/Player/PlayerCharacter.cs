using UnityEngine;

namespace Obscuity.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        private const string PLAYING_CARD = "PlayingCard";
        private const string ENEMY = "Enemy";

        [SerializeField] private int startHp;
        [SerializeField] private int startArmor;
        [SerializeField] private int startMana;
        [SerializeField] private PlayerBar playerBar;
        [SerializeField] private GameObject cardDeck;

        private PlayingCards _holdCard;
        private Camera _mainCamera;
       
        private Vector3 _startPositionHoldCard;
        private Vector3 _offset;

        private LayerMask _layerMask;
        private LayerMask _layerMaskEnemy;

        private int _currentArmor;
        private int _currentHp;
        private int _currentMana;

        public int StartHp => startHp;

         
        public int StartMana => startMana;

        public int StartArmor => startArmor;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _layerMask = LayerMask.GetMask(PLAYING_CARD);
            _layerMaskEnemy = LayerMask.GetMask(ENEMY);
        }

        private void Start()
        {
            Instantiate(cardDeck);
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
                        _startPositionHoldCard = _holdCard.transform.position;
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
                Destroy(_holdCard.gameObject);
            }
            else
            {
                _holdCard.gameObject.transform.position = _startPositionHoldCard;
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