using System;
using System.Text.RegularExpressions;

namespace MemoryWordGame
{
    public class GameEasyLevel
    {
        static Regex rgx;
        public static void GameEasy(int chances, string[,] wordsArray, string[,] viewArray, int pairsRevealed)
        {
            do
            {
                if (chances < 0) //lose condition
                {
                    Console.Clear();
                    Console.WriteLine("You Lost!\n");
                }

                if (pairsRevealed == 4) //win condition
                {
                    Console.Clear();
                    Console.WriteLine("You Won!\n");
                }

                ViewEasy(chances, viewArray);
                rgx = new Regex(@"^[A-B][1-4]$");
                string coordinatesFirstGuess;
                do
                {
                    coordinatesFirstGuess = ReadUserInput.CoordinatesEasyDifficultyInput(); //user input first guess
                }
                while (!rgx.IsMatch(coordinatesFirstGuess));


                int[] arrayCoordinatesFirstGuess = MemoryGameLogic.CoordinatesConverterEasy(coordinatesFirstGuess);

                if (MemoryGameLogic.WordAlreadyRevealedCheck(arrayCoordinatesFirstGuess, viewArray)) //word already revealed
                {
                    chances--;
                }

                MemoryGameLogic.ViewArrayShowWord(arrayCoordinatesFirstGuess, wordsArray, viewArray); //word not revealed yet, continue

                ViewEasy(chances, viewArray);

                string coordinatesSecondGuess;
                do
                {
                    coordinatesSecondGuess = ReadUserInput.CoordinatesEasyDifficultyInput();  //user input second guess
                }
                while (!rgx.IsMatch(coordinatesSecondGuess));


                if (coordinatesFirstGuess == coordinatesSecondGuess) //player put the same coordinates on second guess
                {
                    MemoryGameLogic.HideArrayWords(arrayCoordinatesFirstGuess, viewArray);
                    chances--;
                }

                int[] arrayCoordinatesSecondGuess = MemoryGameLogic.CoordinatesConverterEasy(coordinatesSecondGuess);

                if (MemoryGameLogic.WordAlreadyRevealedCheck(arrayCoordinatesSecondGuess, viewArray)) //second word already revealed
                {
                    MemoryGameLogic.HideArrayWords(arrayCoordinatesFirstGuess, viewArray);
                    chances--;
                }

                MemoryGameLogic.ViewArrayShowWord(arrayCoordinatesSecondGuess, wordsArray, viewArray);

                ViewEasy(chances, viewArray);

                if (!MemoryGameLogic.WordsMatchCheck(arrayCoordinatesFirstGuess, arrayCoordinatesSecondGuess, wordsArray)) //words dont match
                {
                    MemoryGameLogic.HideArrayWords(arrayCoordinatesFirstGuess, arrayCoordinatesSecondGuess, viewArray);
                    chances--;
                }
                else //player succesfully guessed a pair of words
                {
                    pairsRevealed++;
                }
            }
            while (chances >= 0 && pairsRevealed != 4);
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
    }
}
