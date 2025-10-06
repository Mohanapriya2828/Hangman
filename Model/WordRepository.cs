using System;
using System.Collections.Generic;
using System.IO;

namespace hangman.model
{
    public class wordrepository
    {
        private readonly string filepath;

        public wordrepository(string filepath)
        {
            this.filepath = filepath;
        }

        public List<word> getallwords()
        {
            var words = new List<word>();
            if (!File.Exists(filepath)) return words;

            foreach (var line in File.ReadAllLines(filepath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    words.Add(new word(line.Trim()));
            }
            return words;
        }

        public void addword(string newword)
        {
            File.AppendAllText(filepath, newword + Environment.NewLine);
        }

        public void deleteword(string delword)
        {
            if (!File.Exists(filepath)) return;

            var lines = new List<string>(File.ReadAllLines(filepath));
            if (lines.Remove(delword))
                File.WriteAllLines(filepath, lines);
        }
    }
}
