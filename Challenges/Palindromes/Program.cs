using System.Text.RegularExpressions;
while (true)
{
    Console.WriteLine("Enter a word or a number to check if it is a palindrome");
    var entry = Console.ReadLine();
    entry = Regex.Replace(entry, @"\s+", "");
    entry = Regex.Replace(entry, @"\.", "");
    char[] reverseArray = entry.ToCharArray();
    Array.Reverse(reverseArray);
    
    if (entry == new string(reverseArray)) Console.WriteLine("It's a palindrome!");
    else Console.WriteLine("That is not a palindrome");
}
