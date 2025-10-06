using System;

namespace hangman.model
{
    public delegate bool guessevent(string word, char[] guessedletters, char guess);

    public static class guessrulefactory
    {
        public static guessevent getrule(string type)
        {
            if (type == "simple")
                return (word, guessedletters, guess) =>
                {
                    bool correct = false;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guess)
                        {
                            guessedletters[i] = guess;
                            correct = true;
                        }
                    }
                    return correct;
                };
            return null;
        }
    }
}
