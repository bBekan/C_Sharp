SortedSet<double> coinsAndNotes = new SortedSet<double> { 0.01 }; //Uvjet da uvijek postoji 0.1 valute kako bi se mušteriji mogao vratiti puni iznos
Console.WriteLine("Enter available bills");
var bills = Console.ReadLine().Split(" ");
foreach(var bill in bills)
{
    coinsAndNotes.Add(Convert.ToDouble(bill));
}
var total = Math.Round(new Random().NextDouble() * 200 - 1,2 );
Console.WriteLine(total);
Console.WriteLine("Your total is: " + total);
Console.WriteLine("Enter payment amount: ");
var payment = double.Parse(Console.ReadLine());
var finishedPayment = checkPayment(coinsAndNotes, payment, total);
if (finishedPayment.Count == 0) Console.WriteLine("Insufficient funds!");
else
{
    Console.WriteLine("Your change is:");
    foreach(var cash in finishedPayment)
    {
        Console.Write(cash+"$ ");
    }
    Console.WriteLine("\nIn total: " + Math.Round(payment - total, 2) + "$");
}

List<double> checkPayment(SortedSet<double> coinsAndNotes, double payment, double total)
{   
    var cashReturn = new List<Double>();
    if(payment >= total)
    {
        int i = coinsAndNotes.Count - 1;
        var toReturn = Math.Round(payment - total, 2);
        while(toReturn > 0)
        {
            var currentNote = coinsAndNotes.ElementAt(i);
            if ( currentNote <= toReturn)
            {
                cashReturn.Add(currentNote);
                toReturn -= currentNote;
                toReturn = Math.Round(toReturn, 2);
            }
            else
            {
                i--;
            }
        }
    }
    return cashReturn;
}