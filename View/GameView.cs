using System;

namespace hangman.view
{
    public class gameview
    {
        public void showgamestate(char[] guessed, int length, int dummy)
        {
            Console.Write("\nWord: ");
            foreach (var c in guessed)
                Console.Write(c + " ");
            Console.WriteLine();
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
