using System;
using System.IO;

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