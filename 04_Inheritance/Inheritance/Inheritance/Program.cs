using Inheritance;

var stack = new MyStack();
try
{
    stack.DisplayElements();
    stack.Push(1);
    stack.Push(2);
    stack.Push(3);
    stack.Push(3);
    stack.Push("Hey!");

    stack.DisplayElements();
    //stack.Push(null);
    Console.WriteLine(stack.Pop());
    Console.WriteLine(stack.Pop());
    Console.WriteLine(stack.Pop());
    Console.WriteLine(stack.Pop());
    Console.WriteLine(stack.Pop());
    //Console.WriteLine(stack.Pop());
    stack.Clear();
    stack.DisplayElements();

}
catch(Exception e)
{
    Console.WriteLine(e);
}
