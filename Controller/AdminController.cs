using hangman.model;
using hangman.view;

namespace hangman.controller
{
    public class admincontroller
    {
        private readonly wordrepository repo;
        private readonly gameview view;

        public admincontroller(wordrepository repo, gameview view)
        {
            this.repo = repo;
            this.view = view;
        }

        public void showmenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Add Word");
                Console.WriteLine("2. Delete Word");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new word: ");
                        string newword = Console.ReadLine();
                        repo.addword(newword);
                        Console.WriteLine("Word added successfully");
                        break;
                    case "2":
                        Console.Write("Enter word to delete: ");
                        string wordtodelete = Console.ReadLine();
                        var allwords = repo.getallwords();
                        if (allwords.Count == 0 || !allwords.Exists(w => w.text == wordtodelete))
                        {
                            Console.WriteLine("Word not found");
                            break;
                        }
                        repo.deleteword(wordtodelete);
                        Console.WriteLine("Word deleted successfully");
                        break;
                    case "3":
                        running = false;
                        break;
                }
            }
        }
    }
}
