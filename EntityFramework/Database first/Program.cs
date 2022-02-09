using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbcontext = new VidzyEntities();
            dbcontext.AddVideo("My first vid!", DateTime.Now, (byte) 1, 3);
            dbcontext.AddVideo("Hello world", DateTime.Now, (byte) 1, 2);
        }
    }
}
