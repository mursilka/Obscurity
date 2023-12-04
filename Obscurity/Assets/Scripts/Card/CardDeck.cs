using System.Collections.Generic;
using Configs;
using Obscuity;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private CardDescriptions cardDescriptions;
    [SerializeField] private GameObject prefab;
    
    private CardsFactory _factory;
    private PlayingCards _playingCards;
    private List<Card> _listCard;
    private List<Card> _listReset;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _playingCards=prefab.GetComponent<PlayingCards>();
        _listCard = new List<Card>();
        _listReset = new List<Card>();

    }

    private void Start()
    {
        _gameManager.OnStartGame += StartingHand;
        _gameManager.OnHandChanged += HandControl; 
    }

    private void AddListCard()
    {
        _factory = new CardsFactory();
        _factory.Init(cardDescriptions);
        for (int i = 1; i < 6; i++)
        {
            var card=_factory.CreateCardModel("Card", 0);
            _listCard.Add(card);
        }

        for (int i = 1; i < 3; i++)
        {
            var card=_factory.CreateCardModel("Card", 1);
            _listCard.Add(card);
        }

        for (int i = 1; i < 5; i++)
        {
            var card=_factory.CreateCardModel("Card", 2);
            _listCard.Add(card);
        }
    }

    private void StartingHand()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            _listReset.Clear();
            _listCard.Clear();
        }
        AddListCard(); 

        for (int i = 1; i < 6; i++)
        {
            var element = _listCard[Random.Range(0, _listCard.Count)]; 
            _playingCards.Initialize(element.CardDescription);
            Instantiate(prefab,transform);
            _listReset.Add(element);
            _listCard.Remove(element);
        } 
    }

    private void HandControl()
    {
        while (transform.childCount < 5)
        {
            if (transform.childCount < 5 && _listCard.Count!=0)
            {
                var element =_listCard[Random.Range(0, _listCard.Count)];
                _playingCards.Initialize(element.CardDescription);
                Instantiate(prefab,transform);
                _listReset.Add(element);
                _listCard.Remove(element);
            }

            if (_listCard.Count == 0)
            {
                _listCard.AddRange(_listReset);
                _listReset.Clear();
            } 
        }

    }

    private void OnDestroy()
    {
        _gameManager.OnStartGame -= StartingHand;
        _gameManager.OnHandChanged -= HandControl;
    }
}
