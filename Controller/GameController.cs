using System;
using System.Collections.Generic;
using Hangman.Model;
using Hangman.View;

namespace Hangman.Controller
{
    public class GameController
    {
        private readonly GameView _view;
        private readonly WordRepository _repo;
        private readonly GuessHandler _guessRule;
        public GameController(GameView view, WordRepository repo, GuessHandler guessRule)
        {
            _view = view;
            _repo = repo;
            _guessRule = guessRule;
        }
        public void PlayGame()
        {
            List<Word> words = _repo.GetAllWords();
            if (words.Count == 0)
            {
                Console.WriteLine("No words available. Ask admin to add words.");
                return;
            }
            Random random = new Random();
            string word = words[random.Next(words.Count)].Text.ToLower();
            GameState state = new GameState(word, lives: 3);
            int wrongGuesses = 0;
            HashSet<char> allGuessedLetters = new HashSet<char>();
            while (state.Lives > 0 && !state.IsWordGuessed())
            {
                _view.ShowGameState(state.GuessedLetters, state.Lives, wrongGuesses);
                char guess = _view.GetGuess();
                if (allGuessedLetters.Contains(guess))
                {
                    Console.WriteLine($"You already guessed '{guess}'. Try another letter.");
                    continue;
                }
                allGuessedLetters.Add(guess);
                bool correct = _guessRule(state.CurrentWord, state.GuessedLetters, guess);
                if (!correct)
                {
                    state.Lives--;
                    wrongGuesses++;
                }
                else
                {
                    state.Lives = 3;
                    wrongGuesses = 0;
                }
            }
            bool won = state.IsWordGuessed();
            _view.ShowGameState(state.GuessedLetters, state.Lives, wrongGuesses, won);
            _view.ShowResult(state.CurrentWord, won);
        }
    }
}
