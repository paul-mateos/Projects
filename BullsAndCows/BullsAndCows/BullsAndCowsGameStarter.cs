using System;
namespace BullsAndCows
{
    class BullsAndCowsGameStarter
    { 
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            BullsAndCowsGame bullsAndCowsGame = new BullsAndCowsGame();
            bullsAndCowsGame.Play();
        }
    }
}