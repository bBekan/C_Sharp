Console.WriteLine("Enter a number to check if it's prime");
var num = Convert.ToInt32(Console.ReadLine());
SortedSet<int> factors = new SortedSet<int> { 1, num };
HashSet<int> primeFactors = new HashSet<int>();

if (num % 2 == 0)
{
    factors.Add(2);
    primeFactors.Add(2);
}
for (int i = 3; i <= num / 2; i += 2)
{
    if (num % i == 0)
    {
        factors.Add(i);
        if (checkFactor(i)) primeFactors.Add(i);
    }
}

if (factors.Count == 2) Console.WriteLine("{0} is prime!", num);
else
{
    Console.WriteLine("Factors: ");
    Console.WriteLine("\t");
    foreach (var n in factors)
    {
        Console.Write(n + " ");
    }

    Console.WriteLine("\nPrime factors:");
    Console.WriteLine("\t");
    foreach (var n in primeFactors)
    {
        Console.Write(n + " ");
    }
}
bool checkFactor(int num)
{
    if (num % 2 == 0)
    {
        return false;
    }
    for (int i = 3; i <= Math.Sqrt(num); i += 2)
    {
        if (num % i == 0)
        {
            return false;
        }
    }
    return true;
}