using System;
using Obscuity;
using Unity.VisualScripting;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private CardDescriptions cardDescriptions;
    [SerializeField] private GameObject prefab;
    private CardsFactory _factory;
    private PlayingCards _playingCards;
    private void Awake()
    {
        _playingCards=prefab.GetComponent<PlayingCards>();
    }

    private void Start()
    {
        _factory = new CardsFactory();
        _factory.Init(cardDescriptions);

        var card=_factory.CreateCardModel("Card", 2);
        _playingCards.Initialize(card.CardDescription);
        Instantiate(prefab);
        
    }
}
