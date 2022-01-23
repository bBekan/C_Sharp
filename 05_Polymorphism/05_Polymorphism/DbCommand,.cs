using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Polymorphism
{
    internal class DbCommand
    {
        private DbConnection connection;
        private string instruction;
        public DbCommand(DbConnection connection, string  instruction)
        {
            if (connection == null || instruction == null) throw new ArgumentNullException("Constructor parameters cannot be null!\n");
            this.connection = connection;
            this.instruction = instruction;
        }

        public void Execute()
        {
            connection.Open();
            Console.WriteLine(instruction);
            connection.Close();
        }
    }
}
