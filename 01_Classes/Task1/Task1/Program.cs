using Task1;

try { 

    //Starting and stoping multiple times
for (int i = 0; i < 2; i++)
    {
        Stopwatch.Start();
        var randTime = new Random();
        Thread.Sleep(randTime.Next(1000, 4000));
        Stopwatch.Stop();
    }

    //Invalid action
    Stopwatch.Start();
    Stopwatch.Start();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex);
}

