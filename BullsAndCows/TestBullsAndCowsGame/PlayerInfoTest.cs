using BullsAndCows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBullsAndCowsGame
{
    [TestClass]
    public class PlayerInfoTest
    {
        private const string INCORRECT_STRING_MSG = 
        "Incorrect string of the PlayerInfo object!";
        private const string INCORRECT_COMPARISON_MSG =
        "Incorrect result of comparison!";

        [TestMethod]
        public void PlayerInfoConstructorTest()
        {
            string expectedName = "Ivan"; 
            int expectedGuessesCount = 5;
            PlayerInfo info = 
                new PlayerInfo(expectedName, expectedGuessesCount);
            bool areNamesEqual = expectedName.Equals(info.Name);
            bool areGuessesCountEqual = 
            expectedGuessesCount.Equals(info.Guesses);

            bool expected = true;
            bool actual = areNamesEqual && areGuessesCountEqual;

            Assert.AreEqual<bool>(actual, expected,
                                  "Incorrect intialization of PlayerInfo object!");
        }

        [TestMethod]
        public void TestCompareToForEqualInfos()
        {
            string expectedName = "Ivan";
            int expectedGuessesCount = 5;
            PlayerInfo firstPlayerInfo = 
                new PlayerInfo(expectedName, expectedGuessesCount);
            PlayerInfo secondPlayerInfo =
                new PlayerInfo(expectedName, expectedGuessesCount);
        
            int expected = 0;
            int actual = firstPlayerInfo.CompareTo(secondPlayerInfo);

            Assert.AreEqual(expected, actual,
                            INCORRECT_COMPARISON_MSG);
        }

        [TestMethod]
        public void TestCompareToSameNamesDifferentGuessesCountShouldCompareByGuessesCount()
        {
            string expectedName = "Ivan";
            int expectedGuessesCount = 3;
            PlayerInfo firstPlayerInfo =
                new PlayerInfo(expectedName, expectedGuessesCount);
            PlayerInfo secondPlayerInfo =
                new PlayerInfo(expectedName, expectedGuessesCount + 1);

            int expected = -1;
            int actual = firstPlayerInfo.CompareTo(secondPlayerInfo);

            Assert.AreEqual(expected, actual,
                            INCORRECT_COMPARISON_MSG);
        }

        [TestMethod]
        public void TestCompareToSameGuessesCountDifferentNamesShouldCompareByName()
        {
            int expectedGuessesCount = 5;
            PlayerInfo firstPlayerInfo = 
                new PlayerInfo("Anton", expectedGuessesCount);
            PlayerInfo secondPlayerInfo =
                new PlayerInfo("Ivan", expectedGuessesCount);

            int expected = -1;
            int actual = firstPlayerInfo.CompareTo(secondPlayerInfo);

            Assert.AreEqual(expected, actual,
                            INCORRECT_COMPARISON_MSG);
        }

        [TestMethod]
        public void TestCompareToNullShouldReturn1()
        {
            int expectedGuessesCount = 5;
            PlayerInfo firstPlayerInfo =
                new PlayerInfo("Anton", expectedGuessesCount);
            PlayerInfo secondPlayerInfo = null;

            int expected = 1;
            int actual = firstPlayerInfo.CompareTo(secondPlayerInfo);

            Assert.AreEqual(expected, actual,
                            INCORRECT_COMPARISON_MSG);
        }

        [TestMethod]
        public void TestToStringFor1Guess()
        {
            PlayerInfo info = new PlayerInfo("Ivan", 1);

            string expected = "Ivan --> 1 guess"; 
            string actual = info.ToString();

            Assert.AreEqual(expected, actual,
                            INCORRECT_STRING_MSG);
        }

        [TestMethod]
        public void TestToStringForMoreThan1Guess()
        {
            PlayerInfo info = new PlayerInfo("Ivan", 3);

            string expected = "Ivan --> 3 guesses";
            string actual = info.ToString();

            Assert.AreEqual(expected, actual,
                            INCORRECT_STRING_MSG);
        }
    }
}