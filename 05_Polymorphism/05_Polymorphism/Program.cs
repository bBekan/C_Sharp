
using _05_Polymorphism;

try
{
    var OrConnection1 = new OracleConnection("orc1");
    var ConnectSql1 = new SqlConnection("sql1");
    var firstCommand = new DbCommand(ConnectSql1, "Select * from appuser");
    var secondCommand = new DbCommand(OrConnection1, "Update appuser set username = admin where...");

    //Šansa da se veza ne uspije ostvariti radi timeouta je postavljena na 1/7

    firstCommand.Execute();
    secondCommand.Execute();

}
catch(Exception e)
{
    Console.WriteLine(e);
}