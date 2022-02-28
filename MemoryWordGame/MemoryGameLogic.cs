using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryWordGame
{
    public class MemoryGameLogic
    {
        static Random rnd = new Random();

        public static int[,] Game(int numberOfWords, int chances, string[] wordsTable, string difficulty)
        {
            List<int> randomWordsIndex = new List<int>();

            for (int i = 0; i < numberOfWords; i++)
            {
                int number = 0;
                do
                {
                    number = RandomWordsTableIndex(wordsTable);
                }
                while (randomWordsIndex.Exists(x => x == number));

                randomWordsIndex.Add(number);
            }

            int[,] wordsArray = new int[numberOfWords, 2];

            List<int> arrayTableCheck = new List<int>();

            for (int i = 0; i < (numberOfWords * 2); i++)
                arrayTableCheck.Add(i);

            for (int i = 0; i < (numberOfWords * 2); i++)
            {
                int boardCoordinates = BoardCoordinatesRandomizer(arrayTableCheck);
                wordsArray[(boardCoordinates / 2), (boardCoordinates % 2)] = randomWordsIndex[i / 2];
            }

            return wordsArray;
        }

        public static void View(int chancesLeft, List<int> randomWordsIndex, string difficulty)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("\tLevel: " + difficulty);
            Console.WriteLine("\tGuess chances: " + chancesLeft + "\n");

        }

        public static int BoardCoordinatesRandomizer(List<int> table)
        {
            int randomIndex = rnd.Next(table.Count);
            int result = table[randomIndex];
            table.RemoveAt(randomIndex);
            return result;
        }

        public static int RandomWordsTableIndex(string[] wordsTable)
        {
            return rnd.Next(wordsTable.Length);
        }
    }
}
