using System;

namespace MemoryWordGame
{
    public class ReadUserInput
    {
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
    }
}
