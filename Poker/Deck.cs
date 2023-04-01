using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Deck
    {
        private Stack<Card> _cards;
        private List<Card> _cardList;
        public int RemainCardCount()
        {
            return _cards.Count;
        }

        public Deck()
        {
            _cards = new Stack<Card>();
            _cardList = new List<Card>();

            string[] patterns = { "♠", "♥", "♦", "♣" };

            for (int number = 1; number <= 13; number++)
            {
                foreach (string pattern in patterns)
                {
                    _cardList.Add(new Card(number, pattern));
                }
            }
        }

        public Card Draw()
        {
            return _cards.Pop();
        }


        public void Shuffle()
        {
            List<Card> cards = new List<Card>(_cards);

            Random random = new Random();

            while (_cardList.Count > 0)
            {
                int index = random.Next(_cardList.Count);
                Card card = _cardList[index];
                _cardList.RemoveAt(index);
                _cards.Push(card);
            }
        }
    }
}
