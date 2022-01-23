using System;


public class OracleConnection : DbConnection
{
	public OracleConnection(string ConnectionString) :base(ConnectionString)
	{
	}


    public override void Close()
    {
        if (!Opened)
        {
            Console.WriteLine("You must first open the connection!");
            return;
        }
        Console.WriteLine("Oracle connection successfully closed");
        Opened = false;
    }

    public override void Open()
    {
        if (Opened)
        {
            Console.WriteLine("The connection is already opened");
            return;
        }
        CheckTimeout();
        Console.WriteLine("Oracle connection successfully opened!");
        Opened = true;
    }
}
