namespace hangman.model
{
    public delegate bool guessevent(string word, char[] guessedletters, char guess);

    public static class guessrules
    {
        public static bool simpleguess(string word, char[] guessedletters, char guess)
        {
            bool correct = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == guess && guessedletters[i] != guess)
                {
                    guessedletters[i] = guess;
                    correct = true;
                }
            }
            return correct;
        }
    }
}
