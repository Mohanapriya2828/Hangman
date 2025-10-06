using System;
using Hangman.Model;
using Hangman.Controller;
using Hangman.View;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string userCsv = "CSV/users.csv";
            string wordCsv = "CSV/words.csv";
            UserRepository userRepo = new UserRepository(userCsv);
            WordRepository wordRepo = new WordRepository(wordCsv);
            LoginView loginView = new LoginView();
            GameView gameView = new GameView();
            LoginController loginController = new LoginController(loginView, userRepo);
            GuessHandler guessRule = GuessRulesFactory.GetRule("simple");
            GameController gameController = new GameController(gameView, wordRepo, guessRule);
            AdminController adminController = new AdminController(wordRepo);

            User loggedInUser = null;
            while (loggedInUser == null)
                loggedInUser = loginController.LoginWithRole();

            if (loggedInUser.Role.ToLower() == "admin")
                adminController.ShowMenu();
            else
            {
                bool playAgain = true;
                while (playAgain)
                {
                    gameController.PlayGame();
                    Console.Write("Do you want to play again? (y/n): ");
                    playAgain = Console.ReadLine().ToLower() == "y";
                }
            }

            Console.WriteLine("Thanks for playing Hangman!");
        }
    }
}
