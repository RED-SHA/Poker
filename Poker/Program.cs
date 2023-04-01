using System;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.AddPlayer("Dealer");
            game.AddPlayer("Player");

            bool isPlay = true;

            while (isPlay)
            {
                game.Play();
                Console.WriteLine("Press Enter to play again or Esc to exit.");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    isPlay = false;
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("Invalid input. Press Enter to play again or Esc to exit.");
                    key = Console.ReadKey();
                }

                Console.Clear();
            }
        }
    }
    
}
