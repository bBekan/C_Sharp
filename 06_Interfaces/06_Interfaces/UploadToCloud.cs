using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Interfaces
{
    internal class UploadToCloud : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Uploading video to cloud....");
        }
    }
}
