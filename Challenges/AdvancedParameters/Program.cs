int sum = 0;

Console.WriteLine("Would you like to cheat? Yes/No");
var answer = Console.ReadLine().ToLower();

if(answer == "no")
{
    Console.Write(DiceRoll(out sum));
}else if(answer == "yes")
{
    Cheat(ref sum);
    Console.Write("(6,6)");
}
else
{
    throw new Exception();
}

Console.WriteLine(" => Sum = " + sum);

Tuple<int, int> DiceRoll(out int sum)
{
    GenerateRandomNumber(out int secondDice, 0, 6);
    GenerateRandomNumber(out int firstDice, 0, 6);
    sum = firstDice + secondDice;
    return Tuple.Create(firstDice, secondDice);
}

void GenerateRandomNumber(out int number, int lowerBound, int upperBound)
{
    number = new Random().Next(lowerBound, upperBound + 1);
}

void Cheat(ref int sum)
{
    sum = 12;
}