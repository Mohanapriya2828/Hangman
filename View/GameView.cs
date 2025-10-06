using System;

namespace hangman.view
{
    public class gameview
    {
        public void showgamestate(char[] guessed, int length, int wrongguesses)
        {
            Console.Write("\nWord: ");
            foreach (var c in guessed)
                Console.Write(c + " ");
            Console.WriteLine();
            drawhangman(wrongguesses);
        }

        private void drawhangman(int wrongguesses)
        {
            if (wrongguesses == 0) return;

            Console.ForegroundColor = ConsoleColor.Red;
            switch (wrongguesses)
            {
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
                    Console.WriteLine("      O");
                    Console.WriteLine("     /|\\");
                    Console.WriteLine("     / \\");
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

        public char getguess()
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

        public void showresult(string word, bool won)
        {
            Console.WriteLine();
            Console.WriteLine(won ? $"You guessed it! The word was {word}." : $"You lost. The word was {word}.");
        }
    }
}
