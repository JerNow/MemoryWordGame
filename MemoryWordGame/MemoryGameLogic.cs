using System;
using System.Collections.Generic;

namespace MemoryWordGame
{
    public class MemoryGameLogic
    {
        static readonly Random rnd = new Random();

        public static string[,] CreatingWordsArray(int numberOfWords, string[] wordsTable)
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

            string[,] wordsArray = new string[numberOfWords, 2];

            List<int> arrayTableCheck = new List<int>();

            for (int i = 0; i < (numberOfWords * 2); i++)
                arrayTableCheck.Add(i);

            for (int i = 0; i < (numberOfWords * 2); i++)
            {
                int boardCoordinates = BoardCoordinatesRandomizer(arrayTableCheck);
                wordsArray[(boardCoordinates / 2), (boardCoordinates % 2)] = wordsTable[randomWordsIndex[i / 2]];
            }

            return wordsArray;
        }

        public static int[] CoordinatesConverterEasy(string coordinates)
        {
            int[] result = new int[2];
            result[1] = char.ToUpper(coordinates[0]) - 65;
            result[0] = coordinates[1] - 49;
            return result;
        }

        public static int[] CoordinatesConverterHard(string coordinates)
        {
            int[] result = new int[2];
            result[1] = char.ToUpper(coordinates[0]) - 65;
            result[0] = coordinates[1] - 49;
            if (result[1] > 1)
            {
                result[1] = result[1] - 2;
                result[0] = result[0] + 4;
            }
            return result;
        }

        public static void ViewArrayShowWord(int[] arrayCoordinates, string[,] wordsArray, string[,] viewArray)
        {
            viewArray[arrayCoordinates[0], arrayCoordinates[1]] = wordsArray[arrayCoordinates[0], arrayCoordinates[1]];
        }

        public static void HideArrayWords(int[] arrayFirstCoordinates, string[,] viewArray)
        {
            viewArray[arrayFirstCoordinates[0], arrayFirstCoordinates[1]] = "X";
        }

        public static void HideArrayWords(int[] arrayFirstCoordinates, int[] arraySecondCoordinates, string[,] viewArray)
        {
            viewArray[arrayFirstCoordinates[0], arrayFirstCoordinates[1]] = "X";
            viewArray[arraySecondCoordinates[0], arraySecondCoordinates[1]] = "X";
        }

        public static bool WordsMatchCheck(int[] arrayFirstCoordinates, int[] arraySecondCoordinates, string[,] wordsArray)
        {
            if (wordsArray[arrayFirstCoordinates[0], arrayFirstCoordinates[1]] == wordsArray[arraySecondCoordinates[0], arraySecondCoordinates[1]])
                return true;
            return false;
        }

        public static bool WordAlreadyRevealedCheck(int[] arrayCoordinates, string[,] viewArray)
        {
            if (viewArray[arrayCoordinates[0], arrayCoordinates[1]] == "X")
                return false;
            return true;
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
