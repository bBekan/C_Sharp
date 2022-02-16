using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    internal class TextAnalyzer
    {
        public Dictionary<string, int> Words { get; private set; }
        public int NumberOfWords { get; private set; }
        public int NumberOfCharacters { get; private set; }
        public int NumberOfAsciiCharacters { get; private set; }
        public string MostUsedWord { get; private set; }
        public char MostUsedChar { get; set; }
        public Dictionary<char, int> Characters { get; private set; }

        public TextAnalyzer(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new Exception("Text cannot be empty!");

            Words = new Dictionary<string, int>();
            Characters =  new Dictionary<char, int>();

            AnalyzeText(text);
        }

        private void AnalyzeText(string text)
        {
            char[] delims = new[] { '\r', '\n', ' ' };
            string[] words = text.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            NumberOfCharacters = text.Replace("\n", "").Length;
            NumberOfAsciiCharacters = string.Join(null, words).ToCharArray().Length;

            foreach (var w in words)
            {
                var alphaString = Regex.Replace(w.ToLower(), "[^a-z -]", "");
                if (Words.Keys.Contains(alphaString))
                {
                    Words[alphaString]++;
                }
                else
                {
                    Words.Add(alphaString, 1);
                }
                foreach (var c in alphaString)
                {
                    if (Characters.Keys.Contains(c))
                    {
                        Characters[c]++;
                    }
                    else
                    {
                        Characters.Add(c, 1);
                    }
                }
            }
            NumberOfWords = Words.Keys.Count;
            MostUsedWord = GetMostUsedKey<string>(Words);
            MostUsedChar = GetMostUsedKey<char>(Characters);
        }

        private T GetMostUsedKey<T>(Dictionary<T, int> entries)
        {
            return entries.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }

}
