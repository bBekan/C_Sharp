using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Interfaces
{
    internal class SendEmail : IActivity
    {
        public string Email { get; set; }
        public SendEmail(string Email)
        {
            this.Email = Email;
        }
        public void Execute()
        {
            Console.WriteLine("Sending email to {0}....", Email);
        }
    }
}
