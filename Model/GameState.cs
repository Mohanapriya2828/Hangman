namespace hangman.model
{
    public class gamestate
    {
        public string currentword { get; set; }
        public char[] guessedletters { get; set; }

        public gamestate(string word)
        {
            currentword = word;
            guessedletters = new char[word.Length];
            for (int i = 0; i < guessedletters.Length; i++)
                guessedletters[i] = '_';
        }

        public bool iswordguessed()
        {
            return new string(guessedletters) == currentword;
        }
    }
}
