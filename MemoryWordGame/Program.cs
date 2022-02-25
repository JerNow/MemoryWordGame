using System;
using System.IO;

namespace MemoryWordGame
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + "Words.txt");
            var _wordsTable = ReadFromFile(AppDomain.CurrentDomain.BaseDirectory + "Words.txt");
        }

        public static string[] ReadFromFile(string path)
        {
            if (path == null) throw new ArgumentNullException();
            var _wordsTable = File.ReadAllLines(path);

            return _wordsTable;
        }
    }
}