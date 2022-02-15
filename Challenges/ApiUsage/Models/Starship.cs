using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsage
{
    internal class Starship : IPrintInfo
    {
            public string Name { get; set; }
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public string CostInCredits { get; set; }
            public string Length { get; set; }
            public string MaxAtmosphering_Speed { get; set; }
            public string Crew { get; set; }
            public string Passengers { get; set; }
            public string Cargo_Capacity { get; set; }
            public string Consumables { get; set; }
            public string Hyperdrive_Rating { get; set; }
            public string MGLT { get; set; }
            public string Starship_Class { get; set; }
            public object[] Pilots { get; set; }
            public string[] Films { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public string Url { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("\n{0} is a {1}. It requires a crew of {2} people and can carry {3} paassengers...", Name, Model, Crew, Passengers);
        }
    }
}
