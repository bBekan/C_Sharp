using CorrectChange;

SortedSet<double> coinsAndNotes = new SortedSet<double> { 0.01 };

//Učitavanje novčanica i kovanica
Console.WriteLine("Enter available bills:");
var bills = Console.ReadLine().Split(" ");

//Stvaranje kase
var cashRegister = new CashRegister(bills);
cashRegister.DisplayAmountToPay();

//Gotovina za plaćajne
Console.WriteLine("\nEnter payment amount: ");
var payment = double.Parse(Console.ReadLine());

cashRegister.HandlePayment(payment);


