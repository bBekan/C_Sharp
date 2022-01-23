using System;


public class SqlConnection : DbConnection
{
    public SqlConnection(string ConnectionString) : base(ConnectionString)
	{
	}


    public override void Close()
    {
        if (!Opened)
        {
            Console.WriteLine("You must first open the connection!");
            return;
        }
        Console.WriteLine("Sql connection successfully closed");
        Opened = false;
    }

    public override void Open()
    {
    CheckTimeout();
    Console.WriteLine("Sql connection successfully opened!");
    Opened = true;
    }
}
