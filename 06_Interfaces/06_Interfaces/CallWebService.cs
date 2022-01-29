using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Interfaces
{
    internal class CallWebService : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Calling third party service...");
        }
    }
}
