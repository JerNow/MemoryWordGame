using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryWordGame
{
    public class MemoryGameLogic
    {
        static Random rnd = new Random();

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

        public static void GameEasy(int chances, string[,] wordsArray, string[,] viewArray)
        {
            ViewEasy(chances, wordsArray, viewArray);
            string coordinatesFirstGuess = ReadUserInput.CoordinatesEasyDifficultyInput();
            int[] arrayCoordinatesFirstGuess = CoordinatesConverter(coordinatesFirstGuess);
            ViewArrayShowWord(arrayCoordinatesFirstGuess, wordsArray, viewArray);
            ViewEasy(chances, wordsArray, viewArray);
            string coordinatesSecondGuess = ReadUserInput.CoordinatesEasyDifficultyInput();
            if (coordinatesFirstGuess == coordinatesSecondGuess)
            {
                //TODO player loses chance same coordinates
            }
            int[] arrayCoordinatesSecondGuess = CoordinatesConverter(coordinatesSecondGuess);
            ViewArrayShowWord(arrayCoordinatesSecondGuess, wordsArray, viewArray);
            if (!WordsCheck(arrayCoordinatesFirstGuess, arrayCoordinatesSecondGuess, wordsArray))
            {
                //TODO reset board lose chance
            }
            if (chances > 0)
            {
                GameEasy(chances, wordsArray, viewArray);
            }
        }

        public static int[] CoordinatesConverter(string coordinates)
        {
            int[] result = new int[2];
            result[1] = char.ToUpper(coordinates[0]) - 65;
            result[0] = coordinates[1] - 49;
            return result;
        }

        public static void ViewEasy(int chancesLeft, string[,] wordsArray, string[,] viewArray)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\tLevel: " + "Easy");
            Console.WriteLine("\tGuess chances: " + chancesLeft + "\n");
            Console.WriteLine(String.Format("|{0,2}|{1,14}|{2,14}|{3,14}|{4,14}|", " ", "1", "2", "3", "4"));
            Console.WriteLine(String.Format("|{0,2}|{1,14}|{2,14}|{3,14}|{4,14}|", "A", viewArray[0, 0], viewArray[1, 0], viewArray[2, 0], viewArray[3, 0]));
            Console.WriteLine(String.Format("|{0,2}|{1,14}|{2,14}|{3,14}|{4,14}|", "B", viewArray[0, 1], viewArray[1, 1], viewArray[2, 1], viewArray[3, 1]));
            Console.WriteLine("----------------------------------------------------------------");
        }

        public static void ViewArrayShowWord(int[] arrayCoordinates, string[,] wordsArray, string[,] viewArray)
        {
            viewArray[arrayCoordinates[0], arrayCoordinates[1]] = wordsArray[arrayCoordinates[0], arrayCoordinates[1]];
        }

        public static bool WordsCheck(int[] arrayFirstCoordinates, int[] arraySecondCoordinates, string[,] wordsArray)
        {
            if (wordsArray[arrayFirstCoordinates[0], arrayFirstCoordinates[1]] == wordsArray[arraySecondCoordinates[0], arraySecondCoordinates[1]])
                return true;
            return false;
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
