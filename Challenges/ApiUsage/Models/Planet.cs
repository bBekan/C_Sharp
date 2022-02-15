using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsage
{
    internal class Planet :IPrintInfo
    {
            public string Name { get; set; }
            public string Rotation_Period { get; set; }
            public string Orbital_Period { get; set; }
            public string Diameter { get; set; }
            public string Climate { get; set; }
            public string Gravity { get; set; }
            public string Terrain { get; set; }
            public string Surface_Water { get; set; }
            public string Population { get; set; }
            public object[] Residents { get; set; }
            public string[] Films { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public string Url { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("\n{0}'s diameter is {1}m and it has a population of {2}", Name, Diameter, Population);
        }
    }
}
