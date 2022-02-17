using System.Text.RegularExpressions;

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
        public string Text { get; set; }

        public TextAnalyzer(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new Exception("Text cannot be empty!");
            Text = text;

            Words = new Dictionary<string, int>();
            Characters = new Dictionary<char, int>();

            AnalyzeText(text);
        }

        private void AnalyzeText(string text)
        {
            NumberOfWords = RemoveDelimiters(text).Count();
            NumberOfCharacters = NumberOfChars(text);
            NumberOfAsciiCharacters = NumberOfAsciiChars(text);
            SetWordCountDictionary(text);
            SetCharacterCountDictionary(text);
            MostUsedWord = GetMostUsedKey<string>(Words);
            MostUsedChar = GetMostUsedKey<char>(Characters);
        }

        public T GetMostUsedKey<T>(Dictionary<T, int> entries)
        {
            return entries.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public string[] RemoveDelimiters(string text)
        {
            char[] delimiters = new[] { '\r', '\n', ' ' };
            return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
        public string[] RemoveDelimiters(string text, char[] delimiters)
        {
            return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        public int NumberOfChars(string text)
        {
            return text.Replace("\n", "").Length;
        }

        public int NumberOfAsciiChars(string text)
        {
            var newText = RemoveDelimiters(text);
            return string.Join(null, newText).ToCharArray().Length;
        }

        public void SetWordCountDictionary(string text)
        {
            var words = RemoveDelimiters(text);
            for (int i = 0; i < words.Length; i++)
                words[i] = Regex.Replace(words[i].ToLower(), "[^a-z -]", "");
            SetDictionary<string>(words);
        }

        public void SetCharacterCountDictionary(string text)
        {
            var words = Regex.Replace(text.ToLower(), "[^a-z -]", "");
            var characters = string.Join(null, RemoveDelimiters(words)).ToCharArray();
            SetDictionary(characters);
        }

        private void SetDictionary<T>(T[] elements) where T : IConvertible
        {
            Dictionary<T, int> dict = new Dictionary<T, int>();
            foreach (var e in elements)
            {
                if (dict.Keys.Contains(e))
                {
                    dict[e]++;
                }
                else
                {
                    dict.Add(e, 1);
                }
                if (typeof(T) == typeof(string)) Words = dict as Dictionary<string, int>;
                else if (typeof(T) == typeof(char)) Characters = dict as Dictionary<char, int>;
                else throw new Exception("Elements of the array must be of type string or char");
            }
        }



    }
}


