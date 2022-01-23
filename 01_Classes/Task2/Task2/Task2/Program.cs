using Task2;
try
{
    var post1 = new Post("Learning C#", "Learning C# through Udemy lessons");
    for (int i = 0; i < 10; i++)
    {
        post1.Like();
    }
    post1.Dislike();
    post1.DisplayPost();

    var post2 = new Post("Nonsense", "This post is nonsensical :P");
    for (int i = 0; i < 20; i++)
    {
        post2.Dislike();
    }

    post2.DisplayPost();
    Console.WriteLine(post2);

    //var post3 = new Post(null, "Empty");
    //post3.DisplayPost();
    var post4 = new Post(" ", "Desc....");
    post4.DisplayPost();


}
catch (ArgumentNullException e)
{
    Console.WriteLine(e + " Title and description cannot be empty or null");
}

