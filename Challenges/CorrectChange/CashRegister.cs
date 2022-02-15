using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectChange
{
    public class CashRegister
    {
        public SortedSet<double> NotesAndCoins { get; set; }
        public double CurrentTotal { get; set; }
        public CashRegister(string[] bills)
        {
            NotesAndCoins = new SortedSet<double> { 0.01 };

            foreach (var bill in bills)
            {
                AddNewBillOrCoin(bill);
            }
        }

        //Nasummično generiana svota za plaćanje
        public double DisplayAmountToPay()
        {
            CurrentTotal = Math.Round(new Random().NextDouble() * 200 - 1, 2);
            Console.WriteLine("\nYour total is: " + CurrentTotal);
            return CurrentTotal;
        }

        //Procesira plaćanje
        public void HandlePayment(double cashRecieved)
        {
            if (cashRecieved < CurrentTotal)
            {
                Console.WriteLine("\nInsufficient funds!");
                return;
            }

            int i = NotesAndCoins.Count - 1;
            var toReturn = Math.Round(cashRecieved - CurrentTotal, 2);

            Console.WriteLine("\nReturn amount: {0}\nBills and coins: ", toReturn);

            while (toReturn > 0)
            {
                var currentNote = NotesAndCoins.ElementAt(i);

                if (currentNote <= toReturn)
                {
                    Console.Write(currentNote + "$ ");
                    toReturn -= currentNote;
                    toReturn = Math.Round(toReturn, 2);
                }
                else
                {
                    i--;
                }
            }
        }

        public void AddNewBillOrCoin(string value)
        {
            double money;

            if (double.TryParse(value, out money)) NotesAndCoins.Add(money);
        }

        public void AddNewBillOrCoin(double value)
        {
            NotesAndCoins.Add(value);
        }
    }
}
