namespace Hangman.Model
{
    public class Word
    {
        public string Text { get; set; }
        public Word(string text)
        {
            Text = text;
        }
    }
}
