namespace hangman.model
{
    public static class guesseventfactory
    {
        public static guessevent getrule(string type)
        {
            return guessrules.simpleguess;
        }
    }
}
