using hangman.model;
using hangman.view;
using hangman.controller;

class program
{
    static void Main()
    {
        string wordcsv = "CSV/words.csv";

        wordrepository repo = new wordrepository(wordcsv);
        gameview view = new gameview();
        admincontroller admin = new admincontroller(repo, view);

        admin.showmenu();
    }
}
