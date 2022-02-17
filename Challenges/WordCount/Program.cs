using WordCount;

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


foreach(var s in tests)
{
    try
    {
        var textAnalyzer = new TextAnalyzer(s);

        var mostUsedWord = textAnalyzer.MostUsedWord;
        var mostUsedChar = textAnalyzer.MostUsedChar;

        Console.WriteLine("Total words: {0}", textAnalyzer.NumberOfWords);
        Console.WriteLine("Total Characters: {0}", textAnalyzer.NumberOfCharacters);
        Console.WriteLine("Character count (minus line returns and spaces): {0}", textAnalyzer.NumberOfAsciiCharacters);
        Console.WriteLine("Most used word: {0} ({1} times)", mostUsedWord, textAnalyzer.Words[mostUsedWord]);
        Console.WriteLine("Most used character: {0} ({1} times)", mostUsedChar, textAnalyzer.Characters[mostUsedChar]);
        Console.WriteLine();
    }
    catch(Exception e)
    {
        Console.WriteLine(e);
    }
    

}

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