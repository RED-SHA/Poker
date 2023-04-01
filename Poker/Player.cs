using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Player
    {
        public Queue<Card> Hand { get; set; }
        public string Name { get; set; }

        public Player(string name)
        {
            Hand = new Queue<Card>();
            Name = name;
        }

        public int Score()
        {
            int playerScore = 0;
            foreach (var hand in Hand)
            {
                playerScore += hand.Number;
            }
            return playerScore;
        }
        public void DrawCard(Deck deck)
        {
            if (Hand.Count >= 2)
            {
                Hand.Clear();
            }
            Hand.Enqueue(deck.Draw());
        }

        public void ShowHand()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"\n{Name}'s hand:\n");

            Console.WriteLine("+-----+");

            foreach (var card in Hand)
            {
                Console.WriteLine($"| {card.Number,-2}  |");
                Console.WriteLine($"|  {card.Pattern,-2}|");
                Console.WriteLine("+-----+");
            }
        }
    }
}
