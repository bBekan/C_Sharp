using ApiUsage;
ApiHelper.InitializeClient();
string id;

Console.WriteLine("1.Characters\n2.Planets\n3.Starships");
Console.Write("Type in the number of the topic you'd like to more know about: ");

var num = Console.ReadLine();
switch (num)
{
    case "1":
        Console.Write("Type in the id of the character you'd like to know more about: ");
        id = Console.ReadLine();
        Character character = await ApiHelper.GetCharacter(id);
        character.PrintInfo();
        break;
    case "2":
        Console.Write("Type in the id of the planet you'd like to know more about: ");
        id = Console.ReadLine();
        Planet planet = await ApiHelper.GetPlanet(id);
        planet.PrintInfo();
        break;
    case "3":
        Console.Write("Type in the id of the starship you'd like to know more about: ");
        id = Console.ReadLine();
        Starship starship = await ApiHelper.GetStarship(id);
        starship.PrintInfo();
        break;
    default:
        Console.WriteLine("Invalid topic input");
        break;
}
