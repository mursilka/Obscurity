using Obscuity;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private CardDescriptions cardDescriptions;
    [SerializeField] private GameObject prefab;
    private CardsFactory _factory;

    private void Start()
    {
        _factory = new CardsFactory();
        _factory.Init(cardDescriptions);

        _factory.CreateCardModel("Card", 0);
        
        
    }
}
