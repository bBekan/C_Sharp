using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesignChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Present> populatePresents = new List<Present>();
            var present1 = new Present{ name = "Legos", cost = 150 };
            var present2 = new Present { name = "Kitchen knife", cost = 300 };
            var present3 = new Present { name = "Socks", cost = 30 };
            var present4 = new Present { name = "Barbie doll", cost = 120 };

            populatePresents.Add(present1);
            populatePresents.Add(present2);
            populatePresents.Add(present3);
            populatePresents.Add(present4);

            var populatePeople = new List<Person>();

            populatePeople.Add(new Person
            {
                address = "Novigradska 2",
                name = "Marko",
                surname = "Markić",
                presents = new List<Present>{ present1, present4 }
            }) ;

            populatePeople.Add(new Person
            {
                address = "Novigradska 2",
                name = "Branko",
                surname = "Markić",
                presents = new List<Present> { present2 }
            });

            populatePeople.Add(new Person
            {
                address = "Starogradska 3",
                name = "Joško",
                surname = "Horvat",
                presents = new List<Present> { present3 }
            });



            using(var db = new ChristmasPresents())
            {
                db.Presents.AddRange(populatePresents);
                db.FriendsAndFamily.AddRange(populatePeople);
                db.SaveChanges();
            }
        }
    }
}
