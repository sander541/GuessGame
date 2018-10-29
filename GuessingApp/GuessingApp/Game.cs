using System;

namespace GuessingApp
{
    public class Game
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            StartGame();
        }
        public static int GenerateRandomNumber()
        {
            Random random = new Random();
            int Number = random.Next(1, 300);

            return Number;
        }

        public static int GetUserNumber()
        {
            Console.Write("Please select a number : ");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out int GuessedNumber);

            return IsNumberCorrect(GuessedNumber);
        }

        public static int IsNumberCorrect(int GuessedNumber)
        {
            if (IsValidRangeNumber(GuessedNumber))
            {
                return GuessedNumber;
            }
            else
            {
                Console.WriteLine("False input, choose your number again");
                return GetUserNumber();
            }
        }

        public static bool IsValidRangeNumber(int selectedNumber)
        {
            if (selectedNumber <= 300 && selectedNumber >= 1)
                return true;
            else
                return false;
        }

        public static void StartGame()
        {
            int CorrectNumber = GenerateRandomNumber();
            int GuessCount = 0;
            bool CorrectGuess = false;

            while (!CorrectGuess)
            {
                int GuessedNumber = GetUserNumber();

                GuessCount++;
                if (GuessedNumber > CorrectNumber)
                {
                    Console.WriteLine("Your guess, '{0}', was higher than correct answer -- move: '{1}'", GuessedNumber, GuessCount);
                }
                if (GuessedNumber < CorrectNumber)
                {
                    Console.WriteLine("Your guess, '{0}', was lower than correct answer -- move: '{1}'", GuessedNumber, GuessCount);
                }
                if (GuessedNumber == CorrectNumber)
                    CorrectGuess = true;
            }

            if (CorrectGuess)
            {
                Console.WriteLine("You Answered correctly within '{0}' moves , the  number was '{1}'", GuessCount, CorrectNumber);
                Console.WriteLine("Press ESC to quit the game or press any other key to start again");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    //closes application
                }
                else
                {
                    Console.Clear();
                    StartGame();
                }
            }
        }
    }
}

