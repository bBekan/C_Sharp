using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsage
{
    internal class Character :IPrintInfo
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public string Hair_Color { get; set; }
        public string Skin_Color { get; set; }
        public string Birth_Year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public string[] Films { get; set; }
        public string[] Species { get; set; }
        public string[] Vehicles { get; set; }
        public string[] Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("\n{0} is {1}cm tall, their gender is {2}.....", Name, Height, Gender);
        }
    }
}
