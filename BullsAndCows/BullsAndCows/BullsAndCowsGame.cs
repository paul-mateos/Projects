using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private const string GOOD_BYE_MSG = "Exx!";
        private const int GUESS_NUMBER_LENGHT = 4;        
        private const string NUMBER_GUESSED_WITHOUT_CHEATS_MSG =
            "Exee! Otkri tainoto chislo {0} {1}.";

        private readonly string InvalidCommandMsg = "Tcc greshna komanda...!";
        private readonly string WelcomeMsg =
            "Znam, che obichash tazi igra da vidim kolko si dobra! Ako uspeesh da q biesh, ima nagrada nakraq.";
                
        private readonly string NumberGuessedWithCheatMsg =
            "Еьеее! Откри числото за {0} {1}" + 
            " и {2} {3}." +
            Environment.NewLine +
            "Digitalno kusmetche: \"You are awsome i zatova poluchavash specialno neshto v browser-a si. Enjoy! :) \"";

        private static Random randomGenerator = new Random();

        public BullsAndCowsGame()
        {
            GetStartValues();          
        }

        public char[] CheatNumber { get; private set; }
        public int Cheats { get; private set; }
        public int GuessesCount { get; private set; }
        public int[] NumberForGuessDigits { get; private set; }

        private void GetStartValues()
        {
            NumberForGuessDigits = new int[GUESS_NUMBER_LENGHT];
            CheatNumber = new char[GUESS_NUMBER_LENGHT] { 'X', 'X', 'X', 'X' };
            this.Cheats = 0;
            this.GuessesCount = 0;
            this.GenerateRandomDigits();
        }

        public void Play()
        {
            Scoreboard scoreBoard = new Scoreboard();
            DisplayWelcomeMessage();
            while (true)
            {
                string command = BullsAndCowsGame.ReadUserCommand();
                if (command == "exit")
                {
                    Console.WriteLine(GOOD_BYE_MSG);
                    return;
                }
                this.ExecuteCommand(scoreBoard, command);
            }
        }

        private void ExecuteCommand(Scoreboard scoreBoard, string command)
        {
            switch (command)
            {
                case "top":
                    {
                        Console.Write(scoreBoard);
                        break;
                    }
                case "restart":
                    {
                        DisplayWelcomeMessage();
                        this.GetStartValues();
                        break;
                    }
                case "help":
                    {
                        string cheatNumnber = this.GetCheat();
                        Console.WriteLine("The number looks like {0}.", cheatNumnber);
                        break;
                    }
                default:
                    {
                        ExecuteDefaultCommand(scoreBoard, command);
                        break;
                    }
            }
        }

        private void ExecuteDefaultCommand(Scoreboard scoreBoard, string command)
        {
            try
            {
                Result guessResult = this.FindBullsAndCowsCount(command);
                this.DisplayCommandResult(scoreBoard, guessResult);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine(Environment.NewLine + WelcomeMsg);
        }

        private static string ReadUserCommand()
        {
            Console.Write("Enter your guess or command: ");
            string command = Console.ReadLine();
            command = command.Trim();

            return command;
        }

        private void DisplayCommandResult(Scoreboard scoreBoard, Result guessResult)
        {
            if (guessResult.Bulls == GUESS_NUMBER_LENGHT)
            {
                if (this.Cheats == 0)
                {
                    DisplayResultWithoutCheats(scoreBoard);
                }
                else
                {
                    DisplayResultWithCheats();
                }
                Console.Write(scoreBoard);
                this.GetStartValues();
            }
            else
            {
                Console.WriteLine(guessResult);
            }
        }

        private void DisplayResultWithCheats()
        {
            string attemptText = GetPluralOrSingularOfWord(this.GuessesCount, "attempt");
            string cheatText = GetPluralOrSingularOfWord(this.Cheats, "cheat");
            string attemptStr = GetPluralOrSingularOfWord(this.GuessesCount, "attempt");
            Console.WriteLine(NUMBER_GUESSED_WITHOUT_CHEATS_MSG, this.GuessesCount, attemptStr);
            System.Diagnostics.Process.Start("https://www.youtube.com/playlist?list=PL1CTk64TxYtAKlTusWjlfsnXgYIb5XsDZ");
        }

        private void DisplayResultWithoutCheats(Scoreboard scoreBoard)
        {
            string attemptStr = GetPluralOrSingularOfWord(this.GuessesCount, "attempt");
            Console.WriteLine(NUMBER_GUESSED_WITHOUT_CHEATS_MSG, this.GuessesCount, attemptStr);
            System.Diagnostics.Process.Start("https://www.youtube.com/playlist?list=PL1CTk64TxYtAKlTusWjlfsnXgYIb5XsDZ");
            scoreBoard.AddPlayerToScoreboard(this.GuessesCount);
        }

        private string GetPluralOrSingularOfWord(int guessCount, string word)
        {
            string attemptStr = guessCount == 1 ? word : word + "s";
            return attemptStr;
        }

        private string GetCheat()
        {
            if (this.Cheats < GUESS_NUMBER_LENGHT)
            {
                while (true)
                {
                    int randPossition = randomGenerator.Next(0, GUESS_NUMBER_LENGHT);
                    if (CheatNumber[randPossition] == 'X')
                    {
                        RevealChosenDigit(randPossition);
                        break;
                    }
                }
                Cheats++;
            }

            string cheatNumber = new String(CheatNumber);
            return cheatNumber;
        }

        private void RevealChosenDigit(int randPossition)
        {
            switch (randPossition)
            {
                case 0:
                    CheatNumber[randPossition] = (char)(NumberForGuessDigits[0] + '0');
                    break;
                case 1:
                    CheatNumber[randPossition] = (char)(NumberForGuessDigits[1] + '0');
                    break;
                case 2:
                    CheatNumber[randPossition] = (char)(NumberForGuessDigits[2] + '0');
                    break;
                case 3:
                    CheatNumber[randPossition] = (char)(NumberForGuessDigits[3] + '0');
                    break;
            }
        }

        private Result FindBullsAndCowsCount(string userGuessNumberText)
        {
            string numberText = userGuessNumberText.Trim();
            if (string.IsNullOrEmpty(numberText) || numberText.Length != GUESS_NUMBER_LENGHT)
            {
                throw new ArgumentException(InvalidCommandMsg);
            }
            try
            {
                int.Parse(numberText);
                int[] guessNumberDigits = ExtractGuessNumberDigits(numberText);
                this.GuessesCount++;
                bool[] bulls = new bool[GUESS_NUMBER_LENGHT];
                int bullsCount = CountBulls(guessNumberDigits, bulls);
                int cowsCount = CountCows(guessNumberDigits, bulls);
                Result guessResult = new Result(bullsCount, cowsCount);

                return guessResult;
            }
            catch (FormatException)
            {
                throw new FormatException(InvalidCommandMsg);
            }
        }

        private int CountCows(int[] guessNumberDigits, bool[] bulls)
        {
            int cowsCount = 0;
            for (int digit = 0; digit < GUESS_NUMBER_LENGHT; digit++)
            {
                if (bulls[digit])
                {
                    continue;
                }
                for (int comparedDigit = 0; comparedDigit < GUESS_NUMBER_LENGHT; comparedDigit++)
                {
                    if (bulls[comparedDigit])
                    {
                        continue;
                    }
                    if (guessNumberDigits[digit] == NumberForGuessDigits[comparedDigit])
                    {
                        cowsCount++;
                        break;
                    }
                }
            }

            return cowsCount;
        }

        private int CountBulls(int[] guessNumberDigits, bool[] bulls)
        {
            int bullsCount = 0;
            for (int i = 0; i < GUESS_NUMBER_LENGHT; i++)
            {
                if (NumberForGuessDigits[i] == guessNumberDigits[i])
                {
                    bulls[i] = true;
                    bullsCount++;
                }
            }

            return bullsCount;
        }

        private int[] ExtractGuessNumberDigits(string numberText)
        {
            int firstDigit = int.Parse(numberText[0].ToString());
            int secondDigit = int.Parse(numberText[1].ToString());
            int thirdDigit = int.Parse(numberText[2].ToString());
            int fourthDigit = int.Parse(numberText[3].ToString());
            int[] guessNumberDigits =
            {
                firstDigit, secondDigit,
                thirdDigit, fourthDigit
            };

            return guessNumberDigits;
        }

        private void GenerateRandomDigits()
        {
            NumberForGuessDigits[0] = randomGenerator.Next(0, 10);
            NumberForGuessDigits[1] = randomGenerator.Next(0, 10);
            NumberForGuessDigits[2] = randomGenerator.Next(0, 10);
            NumberForGuessDigits[3] = randomGenerator.Next(0, 10);
        }
    }
}