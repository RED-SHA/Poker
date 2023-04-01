using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Game
    {
        private Deck _deck = new Deck();
        private List<Player> _players;

        public Game()
        {
            _players = new List<Player>();
            _deck.Shuffle();
        }

        public void AddPlayer(string name)
        {
            _players.Add(new Player(name));
        }

        public void DealCards()
        {
            foreach (Player player in _players)
            {
                player.DrawCard(_deck);
                player.DrawCard(_deck);
            }
        }

        public void Play()
        {
            if (_deck.RemainCardCount() <= 0)
            {
                _deck = null;
                _deck = new Deck();
                _deck.Shuffle();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[system] Shuffle!");
            }

            DealCards();

            foreach (Player player in _players)
            {
                player.ShowHand();
            }

            JudgeWinner();
        }

        public void JudgeWinner()
        {
            Player winner = null;
            int winnerScore = 0;
            bool isDraw = false;
            
            foreach (Player player in _players)
            {
                int playerScore = player.Score();

                if (winnerScore < playerScore && playerScore <= 21)
                {
                    isDraw = false;
                    winnerScore = playerScore;
                    winner = player;
                }
                else if (winnerScore == playerScore)
                {
                    winnerScore = playerScore;
                    isDraw = true;
                }
            }

            if (winner == null)
            {
                winnerScore += _players[0].Score();                
            }

            Console.WriteLine();

            if (isDraw || winner == null)
            {
                Console.WriteLine($"Winner : Draw, Number is {winnerScore}");
            }
            else
            {
                Console.ForegroundColor = winner.Name == "Dealer" ? ConsoleColor.Red : ConsoleColor.Green;

                Console.WriteLine($"Winner : {winner.Name}, Number is {winnerScore}");
            }

        }
    }
}
