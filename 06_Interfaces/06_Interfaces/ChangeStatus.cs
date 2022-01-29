using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Interfaces
{

    internal class ChangeStatus : IActivity
    {
        public enum Status
        {
            Processing,
            Done,
        }

        public void Execute()
        {
            Console.WriteLine("Current status: {0}", Status.Processing);
            Console.WriteLine(Status.Done);
        }
    }
}
