using System;
using System.Text;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class Scoreboard
    {
        private const int MAX_PLAYERS_COUNT_IN_SCOREBOARD = 5;
        private List<PlayerInfo> scoreboard;

        public Scoreboard()
        {
            this.scoreboard = new List<PlayerInfo>();
        }

        public void AddNewResult(PlayerInfo newPlayer)
        {
            this.scoreboard.Add(newPlayer);
        }

        public override string ToString()
        {
            if (scoreboard.Count == 0)
            {
                string emptyResult = "Top scoreboard is empty." + Environment.NewLine;
                return emptyResult;
            }
            else
            {
                string scoreBoard = CreateScoreboardText();

                return scoreBoard;
            }
        }

        private string CreateScoreboardText()
        {
            StringBuilder scoreBoard = new StringBuilder();
            int count = 0;

            scoreboard.Sort();

            scoreBoard.AppendLine("Scoreboard:");
            foreach (PlayerInfo currentPlayer in scoreboard)
            {
                count++;
                scoreBoard.AppendLine(string.Format("{0}. {1}", count, currentPlayer));
                if (count == MAX_PLAYERS_COUNT_IN_SCOREBOARD)
                {
                    break;
                }
            }

            return scoreBoard.ToString();
        }

        public void AddPlayerToScoreboard(int guessesCount)
        {
            string name = String.Empty;
            while (name == String.Empty)
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                name = Console.ReadLine();
                if (name == String.Empty)
                {
                    Console.WriteLine(Environment.NewLine + "Your name for the scoreboard should" +
                        " consists from at least 1 symblol! Try again!");
                }
            }

            PlayerInfo newPlayerForAdd =
            new PlayerInfo(name, guessesCount);
            this.AddNewResult(newPlayerForAdd);
        }
    }
}