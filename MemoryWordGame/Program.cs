using System;
using System.IO;

namespace MemoryWordGame
{
    public class Program
    {
        static void Main()
        {
            var _wordsTable = ReadFromTextFile(AppDomain.CurrentDomain.BaseDirectory + "Words.txt");

            GameInstance(_wordsTable);
        }

        static void GameInstance(string[] wordsTable)
        {
            Console.WriteLine("Memory Word Game\n");
            Console.WriteLine("Please choose your difficulty level:");
            Console.Write("(Easy/Hard) ");

            string _difficulty = ReadUserInput.DifficultyLevelInput();

            string[,] _wordsArray;
            string[,] _viewArray;

            switch (_difficulty)
            {
                case "Easy":
                    _wordsArray = MemoryGameLogic.CreatingWordsArray(4, wordsTable);
                    _viewArray = new string[4, 2];
                    for (int i = 0; i < _viewArray.Length; i++)
                        _viewArray[i / 2, i % 2] = "X";
                    MemoryGameLogic.GameEasy(10, _wordsArray, _viewArray, 0);
                    break;
                case "Hard":
                    _wordsArray = MemoryGameLogic.CreatingWordsArray(8, wordsTable);
                    _viewArray = new string[8, 2];
                    for (int i = 0; i < _viewArray.Length; i++)
                        _viewArray[i / 2, i % 2] = "X";
                    MemoryGameLogic.GameHard(15, _wordsArray, _viewArray, 0);
                    break;
            }

            Console.WriteLine("Do you Wish to play another round?\n");
            Console.Write("(Yes/No) ");

            string _playerChoice = ReadUserInput.ConfirmationInput();

            if (_playerChoice == "Yes")
            {
                Console.Clear();
                GameInstance(wordsTable);
            }
        }

        public static string[] ReadFromTextFile(string path)
        {
            if (path == null) throw new ArgumentNullException();
            if (!File.Exists(path)) throw new FileNotFoundException();
            if (Path.GetExtension(path) != ".txt") throw new InvalidDataException();
            var _table = File.ReadAllLines(path);
            return _table;
        }
    }
}