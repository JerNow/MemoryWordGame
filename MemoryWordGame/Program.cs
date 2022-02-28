using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MemoryWordGame
{
    public class Program
    {
        static void Main()
        {
            var _wordsTable = ReadFromTextFile(AppDomain.CurrentDomain.BaseDirectory + "Words.txt");
            
            Console.WriteLine("Memory Word Game\n");
            Console.WriteLine("Please choose your difficulty level:");
            Console.Write("(Easy/Hard) ");
            string _difficulty = ReadUserInput.DifficultyLevelInput();
            Console.WriteLine($"You have selected {_difficulty} level");
            string[,] _wordsArray = MemoryGameLogic.CreatingWordsArray(4, _wordsTable);
            string[,] _viewArray = new string[4,2];
            for (int i = 0; i < _viewArray.Length; i++)
                _viewArray[i / 2, i % 2] = "X";
            //MemoryGameLogic.View(10, _wordsArray, _viewArray, _difficulty);
            MemoryGameLogic.GameEasy(10, _wordsArray, _viewArray);
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