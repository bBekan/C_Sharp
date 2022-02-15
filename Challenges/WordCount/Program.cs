using System.Text.RegularExpressions;

string[] tests = new string[]
{
            @"The test of the 
            best way to handle

multiple lines,   extra spaces and more.",
            @"Using the starter app, create code that will 
loop through the strings and identify the total 
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
};

/* 
    First string (tests[0]) Values:
    Total Words: 14
    Total Characters: 89
    Character count (minus line returns and spaces): 60
    Most used word: the (2 times)
    Most used character: e (10 times)

    Second string (tests[1]) Values:
    Total Words: 45
    Total Characters: 276
    Character count (minus line returns and spaces): 230
    Most used word: the (6 times)
    Most used character: t (24 times)
*/
Dictionary<string, int> words = new Dictionary<string, int>();
Dictionary<char, int> chars = new Dictionary<char, int>();
char[] delims = new[] { '\r', '\n',  ' ' };

foreach(var s in tests)
{
    string[] wordArray = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine("Total words: {0}", wordArray.Length);
    Console.WriteLine("Total Characters: {0}",s.Replace("\n", "").Length);
    Console.WriteLine("Character count (minus line returns and spaces): {0}", string.Join(null, wordArray).ToCharArray().Length);
    foreach (var z in wordArray)
    {
        var alphaString = Regex.Replace(z.ToLower(), "[^A-Za-z0-9 -]", "");
        if (words.Keys.Contains(alphaString))
        {
            words[alphaString]++;
        }
        else
        {
            words.Add(alphaString, 1);
        }
        foreach(var c in alphaString)
        {
            if (chars.Keys.Contains(c))
            {
                chars[c]++;
            }
            else
            {
                chars.Add(c, 1);
            }
        }
    }

    var maxWords = words.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
    Console.WriteLine("Most used word: {0} ({1} times)", maxWords, words[maxWords]);

    var maxChars = chars.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
    Console.WriteLine("Most used character: {0} ({1} times)", maxChars, chars[maxChars]);

    words.Clear();
    chars.Clear();
    Console.WriteLine();
}