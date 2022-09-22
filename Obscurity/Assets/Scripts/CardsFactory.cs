using System;
using System.Collections.Generic;
using UnityEngine;

namespace Obscuity
{
    public class CardsFactory
    {
        
        
        private Dictionary<string, Func<int,Card>> cardFactory;

        public void Init(CardDescriptions descriptions)
        {
            cardFactory = new Dictionary<string, Func<int, Card>>()
            {
                { "Card", (CardType) => new Card(descriptions.ListCards[CardType]) }

            };

        }
        public Card CreateCardModel(string nameCard, int CardType)
        {
            Debug.Log("2");
            return cardFactory[nameCard](CardType);
        }
    }
}