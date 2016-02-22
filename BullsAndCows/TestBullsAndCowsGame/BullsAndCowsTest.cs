using System;
using System.IO;
using System.Text;
using BullsAndCows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBullsAndCowsGame
{
    [TestClass()]
    public class BullsAndCowsTest
    {
        private const string INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG =
        "Incorrect count of founded bulls and cows.";
        private const string INCORRECT_PARAMETER_PASSED_MSG =
        "Passing a incorrect number to the method" + 
        " doesn't throw ArgumentException!";
        private const string INCORRECT_CHEAT_NUMBER_MSG =
        "Incorrect cheat number generated!";
        private const string INCORRECT_CHEATS_COUNT_MSG =
        "Incorrect cheats count!";
        private const string READING_COMMMAND_ERROR_MSG = 
        "There was an error in reading the user command!";
        private const string EXECUTING_COMMAND_ERROR_MSG = 
        "There was a problem in executing the given command right!";

        [TestMethod]
        public void TestFindBullsAndCowsCountFor4EqualDigits()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(1, 2, 3, 4);
            string userNumber = "1234";

            Result expected = new Result(4, 0);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        public void TestFindBullsAndCowsCountFor4DifferentDigits()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "1234";

            Result expected = new Result(0, 0);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        public void TestFindBullsAndCowsCountFor4Cows()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(4, 3, 2, 1);
            string userNumber = "1234";

            Result expected = new Result(0, 4);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        public void TestFindBullsAndCowsCountFor2BullsAnd2Cows()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(1, 2, 4, 3);
            string userNumber = "1234";

            Result expected = new Result(2, 2);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        public void TestFindBullsAndCowsCountFor1CowBy3EqualDigits()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(1, 0, 0, 0);
            string userNumber = "0243";

            Result expected = new Result(0, 1);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        public void TestFindBullsAndCowsCountFor1BullByEqualDigits()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "0143";

            Result expected = new Result(1, 0);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        public void TestFindBullsAndCowsFor1BullGuessNumberConsistsEqualDigits()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(4, 3, 8, 6);
            string userNumber = "4444";

            Result expected = new Result(1, 0);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
             "Passing a number with more than 4 digits to the method" +
             " doesn't throw ArgumentException!")]
        public void TestFindBullsAndCowsCountForLongNumber()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "01431";

            Result actual = game.FindBullsAndCowsCount(userNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
             "Passing a number with less than 4 digits to the method" + 
             " doesn't throw ArgumentException!")]
        public void TestFindBullsAndCowsCountForShortNumber()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "01";

            Result actual = game.FindBullsAndCowsCount(userNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
             INCORRECT_PARAMETER_PASSED_MSG)]
        public void TestFindBullsAndCowsCountForEmptyNumber()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "";

            Result actual = game.FindBullsAndCowsCount(userNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException),
             INCORRECT_PARAMETER_PASSED_MSG)]
        public void TestFindBullsAndCowsCountFor3DigitsAnd1Letter()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "123a";

            Result actual = game.FindBullsAndCowsCount(userNumber);
        }

        [TestMethod]
        public void TestFindBullsAndCowsCountFor4BullsWithSpacesBeforeNumber()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "   0000";

            Result expected = new Result(4, 0);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        public void TestFindBullsAndCowsCountFor4BullsWithSpacesAfterNumber()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "0000  ";

            Result expected = new Result(4, 0);
            Result actual = game.FindBullsAndCowsCount(userNumber);

            Assert.AreEqual<Result>(expected, actual,
                                    INCORRECT_COUNT_OF_BULLS_AND_COWS_MSG);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
             INCORRECT_PARAMETER_PASSED_MSG)]
        public void TestFindBullsAndCowsCountForInputWithSpacesBetweenDigits()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(0, 0, 0, 0);
            string userNumber = "1 2 3 5";

            Result actual = game.FindBullsAndCowsCount(userNumber);
        }

        [TestMethod]
        public void TestGenerateRandomDigits()
        {
            BullsAndCowsGame_Accessor game =
            new BullsAndCowsGame_Accessor();
            game.GenerateRandomDigits();

            int repeatedSameNumbersCount = 0;
            int previousFirstDigit = 0;
            int previousSecondDigit = 0;
            int previousThirdDigit = 0;
            int previousFourthDigit = 0;

            for (int i = 0; i < 100; i++)
            {
                game.GenerateRandomDigits();
                int currentFirstDigit = game.NumberForGuessDigits[0];
                int currentSecondDigit = game.NumberForGuessDigits[1];
                int currentThirdtDigit = game.NumberForGuessDigits[2];
                int currentFourthDigit = game.NumberForGuessDigits[3];
                bool isCurrentEqualToPreviousNumber =
                     currentFirstDigit == previousFirstDigit &&
                     currentSecondDigit == previousSecondDigit &&
                     currentThirdtDigit == previousThirdDigit &&
                     currentFourthDigit == previousFourthDigit;
                if (isCurrentEqualToPreviousNumber)
                {
                    repeatedSameNumbersCount++;
                }
                previousFirstDigit = currentFirstDigit;
                previousSecondDigit = currentSecondDigit;
                previousThirdDigit = currentThirdtDigit;
                previousFourthDigit = currentFourthDigit;
            }

            if (repeatedSameNumbersCount > 5)
            {
                Assert.Fail("Too many equal numbers are generated!");
            }
        }

        [TestMethod]
        public void TestGetCheatFor4CallingsHelp()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(1, 2, 3, 4);

            string expected = "1234";
            string actual = String.Empty;
            for (int i = 0; i < 4; i++)
            {
                actual = game.GetCheat();
            }

            Assert.AreEqual<string>(expected, actual,
                                    INCORRECT_CHEAT_NUMBER_MSG);
        }

        [TestMethod]
        public void TestGetCheatCountAfter3CallingsOfHelp()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(1, 2, 3, 4);
            game.Cheats = 3;

            int expectedCheatsCount = 4;
            string actualCheatNumber = game.GetCheat();
            int actualCheatsCount = game.Cheats;

            Assert.AreEqual<int>(actualCheatsCount, expectedCheatsCount,
                                 INCORRECT_CHEATS_COUNT_MSG);
        }

        [TestMethod]
        public void TestGetCheat10CallingsOfHelp()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(1, 2, 3, 4);

            string expected = "1234";
            string actual = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                actual = game.GetCheat();
            }

            Assert.AreEqual<string>(expected, actual,
                                    INCORRECT_CHEAT_NUMBER_MSG);
        }

        [TestMethod()]
        public void TestGetCheat10CallingsOfHelpCheatsCountShouldBe4()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(1, 2, 3, 4);

            int expectedCheatsCount = 4;
            string actualCheatNumber = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                actualCheatNumber = game.GetCheat();
            }
            int actualCheatsCount = game.Cheats;

            Assert.AreEqual<int>(actualCheatsCount, expectedCheatsCount,
                                 INCORRECT_CHEATS_COUNT_MSG);
        }

        [TestMethod]
        public void TestGetCheatIsOnlyOneDigitRevealedAtTime()
        {
            BullsAndCowsGame_Accessor game =
            SetSecretNumberDigits(1, 2, 3, 4);

            string actualCheatNumber = String.Empty;
            for (int i = 3; i >= 0; i--)
            {
                int expectedUnrevealedCount = i;
                actualCheatNumber = game.GetCheat();
                int currentUnrevealedCount =
                CountUnrevealedDigits(game.CheatNumber);

                Assert.AreEqual<int>(currentUnrevealedCount, expectedUnrevealedCount,
                                     INCORRECT_CHEATS_COUNT_MSG);
            }
        }

        [TestMethod]
        public void TestGetStartValuesCount()
        {
            BullsAndCowsGame_Accessor game =
            new BullsAndCowsGame_Accessor();
            game.GenerateRandomDigits();
            game.GetCheat();
            game.GetStartValues();

            int expected = 0;
            int actual = game.Cheats;

            Assert.AreEqual<int>(expected, actual,
                                 "GetStartValues didn't make used cheats number 0.");
        }

        [TestMethod]
        public void TestGetStartValuesCheatNumber()
        {
            BullsAndCowsGame_Accessor game = new BullsAndCowsGame_Accessor();
            game.GenerateRandomDigits();
            game.GetCheat();
            game.GetStartValues();

            char[] expected = { 'X', 'X', 'X', 'X' };
            char[] actual = game.CheatNumber;

            CollectionAssert.AreEqual(expected, actual,
                                      "GetStartValues didn't intialize the help cheat array properly!");
        }

        [TestMethod]
        public void TestGetStartValuesGuessesCount()
        {
            BullsAndCowsGame_Accessor game = new BullsAndCowsGame_Accessor();
            game.FindBullsAndCowsCount("9999");
            game.GetStartValues();

            int expected = 0;
            int actual = game.GuessesCount;

            Assert.AreEqual<int>(expected, actual,
                                 "GetStartValues didn't intialize the guess count properly!");
        }

        [TestMethod]
        public void TestWelcomeMessage()
        {
            BullsAndCowsGame_Accessor game = new BullsAndCowsGame_Accessor();
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);
            game.DisplayWelcomeMessage();
            writer.Close();

            string expected = Environment.NewLine + "Welcome to “Bulls and Cows” game." +
                              "Please try to guess my secret 4-digit number." + Environment.NewLine +
                              "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help'" +
                              " to cheat and 'exit' to quit the game." + Environment.NewLine;
            string actual = sb.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    "The welcme message was incorrect!");
        }

        [TestMethod]
        public void TestReadUserCommandTextCommand()
        {
            BullsAndCowsGame_Accessor game = new BullsAndCowsGame_Accessor();
            StringReader reader = new StringReader(" restart ");
            Console.SetIn(reader);

            string expected = "restart";
            string actual = BullsAndCowsGame_Accessor.ReadUserCommand();
            reader.Close();

            Assert.AreEqual<string>(expected, actual,
                                    READING_COMMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestReadUserCommandGuessNumber()
        {
            BullsAndCowsGame_Accessor game = new BullsAndCowsGame_Accessor();
            StringReader reader = new StringReader(" 2356 ");
            Console.SetIn(reader);

            string expected = "2356";
            string actual = BullsAndCowsGame_Accessor.ReadUserCommand();
            reader.Close();

            Assert.AreEqual<string>(expected, actual,
                                    READING_COMMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestGetPluralOrSingularOfWordSingular()
        {
            BullsAndCowsGame_Accessor game = new BullsAndCowsGame_Accessor();

            string expected = "cheat";
            string actual = game.GetPluralOrSingularOfWord(1, "cheat");

            Assert.AreEqual<string>(expected, actual,
                                    "There was a problem in getting a singular of the word!");
        }

        [TestMethod]
        public void TestGetPluralOrSingularOfWordPlural()
        {
            BullsAndCowsGame_Accessor game = new BullsAndCowsGame_Accessor();

            string expected = "cheats";
            string actual = game.GetPluralOrSingularOfWord(2, "cheat");

            Assert.AreEqual<string>(expected, actual,
                                    "There was a problem in getting a plural of the word!");
        }

        [TestMethod]
        public void TestExecuteCommandTop()
        {
            BullsAndCowsGame_Accessor game = SetSecretNumberDigits(1, 2, 3, 4);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddNewResult(new PlayerInfo("Tisho", 1));
            game.ExecuteCommand(scoreboard, "top");
            writer.Close();

            string expected = "Scoreboard:" + Environment.NewLine +
                              "1. Tisho --> 1 guess" + Environment.NewLine;
            string actual = sb.ToString();
            
            Assert.AreEqual<string>(expected, actual,
                                    EXECUTING_COMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestExecuteCommandRestartMessage()
        {
            BullsAndCowsGame_Accessor game = SetSecretNumberDigits(1, 2, 3, 4);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);
            game.ExecuteCommand(null, "restart");
            writer.Close();

            string expected = Environment.NewLine + game.WelcomeMsg + Environment.NewLine;
            string actual = sb.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    EXECUTING_COMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestExecuteCommandRestartCorrect()
        {
            BullsAndCowsGame_Accessor game = SetSecretNumberDigits(1, 2, 3, 4);
            game.FindBullsAndCowsCount("0000");
            game.ExecuteCommand(null, "0000");
            game.ExecuteCommand(null, "restart");

            int expected = 0;
            int actual = game.GuessesCount;

            Assert.AreEqual<int>(expected, actual,
                                 EXECUTING_COMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestExecuteCommandHelp()
        {
            BullsAndCowsGame_Accessor game = SetSecretNumberDigits(1, 2, 3, 4);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);
            game.CheatNumber = new char[4] { 'X', '2', '3', '4' };
            game.ExecuteCommand(null, "help");
            writer.Close();

            string expected = "The number looks like 1234." + Environment.NewLine;
            string actual = sb.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    EXECUTING_COMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestExecuteCommandInvalidCommand()
        {
            BullsAndCowsGame_Accessor game = SetSecretNumberDigits(1, 2, 3, 4);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);

            game.ExecuteCommand(null, "bau");
            writer.Close();

            string expected = game.InvalidCommandMsg + Environment.NewLine;
            string actual = sb.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    EXECUTING_COMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestExecuteCommandWrongNumber()
        {
            BullsAndCowsGame_Accessor game = SetSecretNumberDigits(1, 2, 3, 4);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);
            game.ExecuteCommand(null, "4321");
            writer.Close();

            string expected = "Wrong number! Bulls: 0, Cows: 4" + Environment.NewLine;
            string actual = sb.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    EXECUTING_COMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestExecuteCommandGuessedMessageWithoutCheats()
        {
            BullsAndCowsGame_Accessor game = SetSecretNumberDigits(1, 2, 3, 4);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);
            StringReader reader = new StringReader("Anton");
            Console.SetIn(reader);
            Scoreboard scoreboard = new Scoreboard();
            game.ExecuteCommand(scoreboard, "1234");
            writer.Close();
            reader.Close();

            string expected = "Congratulations! You guessed the secret number in 1 attempt." + 
                               Environment.NewLine +
                              "Please enter your name for the top scoreboard: " +
                              "Scoreboard:" + Environment.NewLine +
                              "1. Anton --> 1 guess" + Environment.NewLine;
            string actual = sb.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    EXECUTING_COMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestExecuteCommandGuessedMessageWithCheats()
        {
            BullsAndCowsGame_Accessor game = SetSecretNumberDigits(1, 2, 3, 4);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);

            Scoreboard scoreboard = new Scoreboard();
            game.GetCheat();
            game.ExecuteCommand(scoreboard, "1234");
            writer.Close();

            string expected = "Congratulations! You guessed the secret number in 1 attempt and 1 cheat." +
                               Environment.NewLine + "You are not allowed to enter the top scoreboard." +
                               Environment.NewLine +
                              "Top scoreboard is empty." + Environment.NewLine;
            string actual = sb.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    EXECUTING_COMMAND_ERROR_MSG);
        }

        [TestMethod]
        public void TestPlay()
        {
            BullsAndCowsGame game = new BullsAndCowsGame();
            BullsAndCowsGame_Accessor accessor = new BullsAndCowsGame_Accessor();
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Console.SetOut(writer);
            StringReader reader = new StringReader("exit");
            Console.SetIn(reader);
            game.Play();
            writer.Close();
            reader.Close();

            string expected = Environment.NewLine + accessor.WelcomeMsg +
                              Environment.NewLine + "Enter your guess or command: " +
                              "Good bye!" + Environment.NewLine;
            string actual = sb.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    EXECUTING_COMMAND_ERROR_MSG);
        }

        private BullsAndCowsGame_Accessor SetSecretNumberDigits(
            int first, int second, int third, int fourth)
        {
            BullsAndCowsGame_Accessor game =
            new BullsAndCowsGame_Accessor();
            game.NumberForGuessDigits[0] = first;
            game.NumberForGuessDigits[1] = second;
            game.NumberForGuessDigits[2] = third;
            game.NumberForGuessDigits[3] = fourth;

            return game;
        }

        private int CountUnrevealedDigits(char[] cheatNumber)
        {
            int unrevealedDigitsCount = 0;
            foreach (char currentDigit in cheatNumber)
            {
                if (currentDigit == 'X')
                {
                    unrevealedDigitsCount++;
                }
            }

            return unrevealedDigitsCount;
        }
    }
}