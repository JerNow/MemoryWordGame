using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MemoryWordGame
{
    public class MemoryGameLogic
    {
        static Random rnd = new Random();
        static Regex rgx;

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

        public static void GameEasy(int chances, string[,] wordsArray, string[,] viewArray, int pairsRevelead, bool flag)
        {
            ViewEasy(chances, viewArray);
            if (chances < 0) //lose condition
            {
                flag = false;
                Console.Clear();
                Console.WriteLine("You Lost!\n");
            }

            if (pairsRevelead == 4) //win condition
            {
                flag = false;
                Console.Clear();
                Console.WriteLine("You Won!\n");
            }

            if (flag)
            {
                rgx = new Regex(@"^[A-B][1-4]$");
                string coordinatesFirstGuess;
                do
                {
                    coordinatesFirstGuess = ReadUserInput.CoordinatesEasyDifficultyInput(); //user input first guess
                }
                while (!rgx.IsMatch(coordinatesFirstGuess));


                int[] arrayCoordinatesFirstGuess = CoordinatesConverterEasy(coordinatesFirstGuess);

                if (WordAlreadyRevealedCheck(arrayCoordinatesFirstGuess, viewArray)) //word already revealed
                {
                    chances--;
                    GameEasy(chances, wordsArray, viewArray, pairsRevelead, flag);
                }

                ViewArrayShowWord(arrayCoordinatesFirstGuess, wordsArray, viewArray); //word not revealed yet, continue

                ViewEasy(chances, viewArray);

                string coordinatesSecondGuess;
                do
                {
                    coordinatesSecondGuess = ReadUserInput.CoordinatesEasyDifficultyInput();  //user input second guess
                }
                while (!rgx.IsMatch(coordinatesSecondGuess));


                if (coordinatesFirstGuess == coordinatesSecondGuess) //player put the same coordinates on second guess
                {
                    HideArrayWords(arrayCoordinatesFirstGuess, viewArray);
                    chances--;
                    GameEasy(chances, wordsArray, viewArray, pairsRevelead, flag);
                }

                int[] arrayCoordinatesSecondGuess = CoordinatesConverterEasy(coordinatesSecondGuess);

                if (WordAlreadyRevealedCheck(arrayCoordinatesSecondGuess, viewArray)) //second word already revealed
                {
                    HideArrayWords(arrayCoordinatesFirstGuess, viewArray);
                    chances--;
                    GameEasy(chances, wordsArray, viewArray, pairsRevelead, flag);
                }

                ViewArrayShowWord(arrayCoordinatesSecondGuess, wordsArray, viewArray);

                ViewEasy(chances, viewArray);

                if (!WordsMatchCheck(arrayCoordinatesFirstGuess, arrayCoordinatesSecondGuess, wordsArray)) //words dont match
                {
                    HideArrayWords(arrayCoordinatesFirstGuess, arrayCoordinatesSecondGuess, viewArray);
                    chances--;
                    GameEasy(chances, wordsArray, viewArray, pairsRevelead, flag);
                }
                else //player succesfully guessed a pair of words
                {
                    pairsRevelead++;
                    GameEasy(chances, wordsArray, viewArray, pairsRevelead, flag);
                }

            }
            else
            {
                return;
            }
        }

        public static void GameHard(int chances, string[,] wordsArray, string[,] viewArray, int pairsRevelead, bool flag)
        {
            ViewHard(chances, viewArray);

            if (chances < 0) //lose condition
            {
                flag = false;
                Console.Clear();
                Console.WriteLine("You Lost!\n");
            }

            if (pairsRevelead == 8) //win condition
            {
                flag = false;
                Console.Clear();
                Console.WriteLine("You Won!\n");
            }

            if (flag)
            {
                rgx = new Regex(@"^[A-D][1-4]$");
                string coordinatesFirstGuess;
                do
                {
                    coordinatesFirstGuess = ReadUserInput.CoordinatesHardDifficultyInput(); //user input first guess
                }
                while (!rgx.IsMatch(coordinatesFirstGuess));

                int[] arrayCoordinatesFirstGuess = CoordinatesConverterHard(coordinatesFirstGuess);

                if (WordAlreadyRevealedCheck(arrayCoordinatesFirstGuess, viewArray)) //word already revealed
                {
                    chances--;
                    GameHard(chances, wordsArray, viewArray, pairsRevelead, flag);
                }

                ViewArrayShowWord(arrayCoordinatesFirstGuess, wordsArray, viewArray); //word not revealed yet, continue

                ViewHard(chances, viewArray);

                string coordinatesSecondGuess;
                do
                {
                    coordinatesSecondGuess = ReadUserInput.CoordinatesHardDifficultyInput(); //user input second guess
                }
                while (!rgx.IsMatch(coordinatesSecondGuess));

                if (coordinatesFirstGuess == coordinatesSecondGuess) //player put the same coordinates on second guess
                {
                    HideArrayWords(arrayCoordinatesFirstGuess, viewArray);
                    chances--;
                    GameHard(chances, wordsArray, viewArray, pairsRevelead, flag);
                }

                int[] arrayCoordinatesSecondGuess = CoordinatesConverterHard(coordinatesSecondGuess);

                if (WordAlreadyRevealedCheck(arrayCoordinatesSecondGuess, viewArray)) //second word already revealed
                {
                    HideArrayWords(arrayCoordinatesFirstGuess, viewArray);
                    chances--;
                    GameHard(chances, wordsArray, viewArray, pairsRevelead, flag);
                }

                ViewArrayShowWord(arrayCoordinatesSecondGuess, wordsArray, viewArray);

                ViewHard(chances, viewArray);

                if (!WordsMatchCheck(arrayCoordinatesFirstGuess, arrayCoordinatesSecondGuess, wordsArray)) //words dont match
                {
                    HideArrayWords(arrayCoordinatesFirstGuess, arrayCoordinatesSecondGuess, viewArray);
                    chances--;
                    GameHard(chances, wordsArray, viewArray, pairsRevelead, flag);
                }
                else //player succesfully guessed a pair of words
                {
                    pairsRevelead++;
                    GameHard(chances, wordsArray, viewArray, pairsRevelead, flag);
                }

            }
            else
            {
                return;
            }
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

        public static void ViewEasy(int chancesLeft, string[,] viewArray)
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

        public static void ViewHard(int chancesLeft, string[,] viewArray)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\tLevel: " + "Hard");
            Console.WriteLine("\tGuess chances: " + chancesLeft + "\n");
            Console.WriteLine(String.Format("|{0,2}|{1,14}|{2,14}|{3,14}|{4,14}|", " ", "1", "2", "3", "4"));
            Console.WriteLine(String.Format("|{0,2}|{1,14}|{2,14}|{3,14}|{4,14}|", "A", viewArray[0, 0], viewArray[1, 0], viewArray[2, 0], viewArray[3, 0]));
            Console.WriteLine(String.Format("|{0,2}|{1,14}|{2,14}|{3,14}|{4,14}|", "B", viewArray[0, 1], viewArray[1, 1], viewArray[2, 1], viewArray[3, 1]));
            Console.WriteLine(String.Format("|{0,2}|{1,14}|{2,14}|{3,14}|{4,14}|", "C", viewArray[4, 0], viewArray[5, 0], viewArray[6, 0], viewArray[7, 0]));
            Console.WriteLine(String.Format("|{0,2}|{1,14}|{2,14}|{3,14}|{4,14}|", "D", viewArray[4, 1], viewArray[5, 1], viewArray[6, 1], viewArray[7, 1]));
            Console.WriteLine("----------------------------------------------------------------");
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

        public static bool WordAlreadyRevealedCheck(int[] arrayCoordinates, String[,] viewArray)
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
