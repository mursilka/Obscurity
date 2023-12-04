namespace Obscuity
{
    public class Card
    {
        private CardDescription _card;

        public CardDescription CardDescription => _card;
        
        public Card (CardDescription description)
        {
            _card = description;
        }

    }
}