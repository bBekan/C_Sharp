using BirthdayCalculator;

Console.Write("Enter you birthday: ");
var input = Console.ReadLine();

var birthday = DateTime.Parse(input);
var bday = new Birthday(birthday);

Console.WriteLine(bday.DOB);
Console.WriteLine(bday.Days);
Console.WriteLine(bday.Months);
Console.WriteLine(bday.Years);
Console.WriteLine(bday.MonthsToBirthday);
Console.WriteLine(bday.WeeksToBirthday);
