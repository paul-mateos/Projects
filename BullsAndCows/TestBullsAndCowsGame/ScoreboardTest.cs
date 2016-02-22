using System;
using System.IO;
using System.Text;
using BullsAndCows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBullsAndCowsGame
{
    [TestClass]
    public class ScoreboardTest
    {
        private const string INCORRECT_STRING_MSG =
        "Incorrect string of Scoreboard class!";

        [TestMethod]
        public void TestAddNewResult()
        {
            Scoreboard_Accessor scoreboard = new Scoreboard_Accessor(); 
            PlayerInfo newPlayer = new PlayerInfo("Gosho",15); 
            scoreboard.AddNewResult(newPlayer);

            int expectedLenght = 1;
            int actualLenght = scoreboard.scoreboard.Count;

            Assert.AreEqual<int>(expectedLenght, actualLenght,
                                 "There was a problem in adding a new result to the scoreboard!");            
        }

        [TestMethod]
        public void TestToStringEmptyScoreboard()
        {
            Scoreboard scoreboard = new Scoreboard();

            string expected = "Top scoreboard is empty." + Environment.NewLine; 
            string actual = scoreboard.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    INCORRECT_STRING_MSG);
        }

        [TestMethod]
        public void TestToStringSortingDifferentGuessesCounts()
        {
            Scoreboard_Accessor scoreboard = 
            new Scoreboard_Accessor();
            for (int i = 1; i < 10; i++)
            {
                PlayerInfo newPlayer = new PlayerInfo("Gosho", i);
                scoreboard.AddNewResult(newPlayer);
            }
           
            string expected = "Scoreboard:" + Environment.NewLine +
                              "1. Gosho --> 1 guess" + Environment.NewLine +
                              "2. Gosho --> 2 guesses" + Environment.NewLine +
                              "3. Gosho --> 3 guesses" + Environment.NewLine +
                              "4. Gosho --> 4 guesses" + Environment.NewLine +
                              "5. Gosho --> 5 guesses" + Environment.NewLine;
            string actual = scoreboard.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    INCORRECT_STRING_MSG);
        }

        [TestMethod]
        public void TestToStringSortingDifferentPlayerNamesEqualGuessesCounts()
        {
            Scoreboard_Accessor scoreboard = new Scoreboard_Accessor();
            string[] names = { "Zoltan", "Yohan", "Kalin", "Barni", "Anton" };
            for (int i = 0; i < 5; i++)
            {
                PlayerInfo newPlayer = new PlayerInfo(names[i], 2);
                scoreboard.AddNewResult(newPlayer);
            }

            string expected = "Scoreboard:" + Environment.NewLine +
                              "1. Anton --> 2 guesses" + Environment.NewLine +
                              "2. Barni --> 2 guesses" + Environment.NewLine +
                              "3. Kalin --> 2 guesses" + Environment.NewLine +
                              "4. Yohan --> 2 guesses" + Environment.NewLine +
                              "5. Zoltan --> 2 guesses" + Environment.NewLine;
            string actual = scoreboard.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    INCORRECT_STRING_MSG);
        }

        [TestMethod]
        public void TestAddPlayerToScoreboard()
        {
            Scoreboard scoreboard = new Scoreboard();
            string userInput = String.Empty + Environment.NewLine + "Ivan";
            StringReader reader = new StringReader(userInput);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetIn(reader);
            Console.SetOut(writer);
            scoreboard.AddPlayerToScoreboard(3);

            string expected = "Please enter your name for the top scoreboard: " + 
                               Environment.NewLine +
                              "Your name for the scoreboard should" +
                              " consists from at least 1 symblol! Try again!" +
                              Environment.NewLine +
                              "Please enter your name for the top scoreboard: ";
            string actual = sb.ToString();          
            reader.Close();
            writer.Close();
            
            Assert.AreEqual<string>(expected, actual,
                                    "There was an error in adding a new player to the scoreboard!");
        }
    }
}