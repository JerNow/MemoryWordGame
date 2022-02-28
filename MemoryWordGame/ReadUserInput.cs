using System;
using System.Text.RegularExpressions;

namespace MemoryWordGame
{
    public class ReadUserInput
    {
        static Regex rgx;
        public static string GetInput()
        {
            return Console.ReadLine();
        }
        public static string DifficultyLevelInput()
        {
            string _userInput = GetInput();
            if (_userInput == null) throw new ArgumentNullException();
            if (_userInput != "Easy" && _userInput != "Hard")
            {
                Console.WriteLine("Wrong input! Please write either Easy, or Hard!");
                DifficultyLevelInput();
            }
            return _userInput;
        }

        public static string ConfirmationInput()
        {
            string _userInput = GetInput();
            if (_userInput == null) throw new ArgumentNullException();
            if (_userInput != "Yes" && _userInput != "No")
            {
                Console.WriteLine("Wrong input, please write either Yes, or No");
                ConfirmationInput();
            }
            return _userInput;
        }

        public static string CoordinatesEasyDifficultyInput()
        {
            string _userInput = GetInput();
            if (_userInput == null) throw new ArgumentNullException();
            rgx = new Regex(@"^[A-B][1-4]$");
            if (!rgx.IsMatch(_userInput))
            {
                Console.WriteLine("Wrong input! Please write Coordinates! (ex. A1, B3)");
                CoordinatesEasyDifficultyInput();
            }
            return _userInput;
        }

        public static string CoordinatesHardDifficultyInput()
        {
            string _userInput = GetInput();
            if (_userInput == null) throw new ArgumentNullException();
            rgx = new Regex(@"^[A-D][1-4]$");
            if (!rgx.IsMatch(_userInput))
            {
                Console.WriteLine("Wrong input! Please write Coordinates! (ex. A1, B3)");
                CoordinatesHardDifficultyInput();
            }
            return _userInput;
        }
    }
}
