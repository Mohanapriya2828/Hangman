using System;
using System.Collections.Generic;
using hangman.model;
using hangman.view;

namespace hangman.controller
{
    public class gamecontroller
    {
        private readonly gameview view;
        private readonly wordrepository repo;
        private readonly guessevent guessrule;

        public gamecontroller(gameview view, wordrepository repo, guessevent guessrule)
        {
            this.view = view;
            this.repo = repo;
            this.guessrule = guessrule;
        }

        public void playgame()
        {
            List<word> words = repo.getallwords();
            if (words.Count == 0) return;

            Random random = new Random();
            string currentword = words[random.Next(words.Count)].text.ToLower();

            char[] guessedletters = new char[currentword.Length];
            for (int i = 0; i < guessedletters.Length; i++)
                guessedletters[i] = '_';

            int lives = 3;
            int wrongguesses = 0;

            while (lives > 0 && new string(guessedletters) != currentword)
            {
                view.showgamestate(guessedletters, currentword.Length, wrongguesses);
                Console.WriteLine($"Lives: {lives}");

                char guess = view.getguess();

                if (Array.Exists(guessedletters, c => c == guess))
                {
                    Console.WriteLine($"You already guessed '{guess}'. Try another letter.");
                    continue;
                }

                bool correct = guessrule(currentword, guessedletters, guess);

                if (!correct)
                {
                    lives--;
                    wrongguesses++;
                }
                else
                {
                    lives = 3;
                    wrongguesses = 0;
                }
            }

            view.showgamestate(guessedletters, currentword.Length, wrongguesses);
            view.showresult(currentword, new string(guessedletters) == currentword);
        }
    }
}
