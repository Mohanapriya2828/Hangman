using System;

namespace Hangman.View
{
    public class GameView
    {
        public void ShowGameState(char[] guessed, int lives, int wrongGuesses, bool won = false)
        {
            Console.Write("\nWord: ");
            foreach (var c in guessed)
                Console.Write(c + " ");
            Console.WriteLine($"  |  Lives: {lives}");
            DrawHangman(wrongGuesses, won);
        }

        private void DrawHangman(int wrongGuesses, bool won = false)
        {
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" \\O/ ");
                Console.WriteLine("   |  ");
                Console.WriteLine(" / \\ ");
                Console.WriteLine("You won! Congratulations!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            switch (wrongGuesses)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("  ______");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 2:
                    Console.WriteLine("  ______");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |   O\"); 
                    Console.WriteLine("  |  /|\\");
                    Console.WriteLine("  |  / \\");
                    Console.WriteLine("__|__");
                    break;
                case 3:
                    Console.WriteLine("  ______");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  |    O");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  |   /|\\");
                    Console.WriteLine("  |   / \\");
                    Console.WriteLine("__|__");
                    Console.WriteLine("Game Over! The man is hanged.");
                    break;
            }
            Console.ResetColor();
        }

        public char GetGuess()
        {
            Console.Write("Enter a letter: ");
            string input = Console.ReadLine().ToLower();
            while (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.Write("Invalid input. Enter a single letter: ");
                input = Console.ReadLine().ToLower();
            }
            return input[0];
        }

        public void ShowResult(string word, bool won)
        {
            Console.WriteLine();
            Console.WriteLine(won ? $"You guessed it! The word was {word}." : $"You lost. The word was {word}.");
        }
    }
}
