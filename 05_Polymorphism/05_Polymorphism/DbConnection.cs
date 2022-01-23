using System;


public abstract class DbConnection
{
	private string ConnectionString;
	private TimeSpan Timeout;
	protected bool Opened;
	public  DbConnection(string ConnectionString)
	{
		if (String.IsNullOrWhiteSpace(ConnectionString)) throw new ArgumentNullException("Connection string cannot be null!\n");
		this.ConnectionString = ConnectionString;
		Timeout = new TimeSpan(0, 0, 5);
		Opened = false;
	}

	public abstract void Open();
	public abstract void Close();
	public void CheckTimeout()
    {
		var randomTime = new Random().Next(0,7);
		var connectionTime = new TimeSpan(0, 0, randomTime);
		var result = TimeSpan.Compare(connectionTime, Timeout);
		if(result == 1)
        {
			throw new TimeoutException("Connection failed due to latency.");
        }
    }


}
