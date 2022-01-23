using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class MyStack
    {
		private ArrayList stack = new ArrayList();
		public MyStack()
		{

		}


		public void Push(Object obj)
		{
			if (obj == null) throw new InvalidOperationException("Null objects cannot be added to the stack!");
			stack.Add(obj);
		}

		public Object Pop()
		{
			if (stack.Count == 0) throw new InvalidOperationException("The stack is empty!");
			Object o = stack[stack.Count - 1];
			stack.Remove(o);
			return o;
		}

		public void DisplayElements()
        {
			if (stack.Count == 0)
			{
				Console.WriteLine("Stack is empty!\n");
				return;
			}
            Console.WriteLine("Elements on the stack are:");
			foreach(Object o in stack)
            {
                Console.Write(o + " ");
            }
            Console.WriteLine("\n");
        }

		public void Clear()
        {
			foreach(Object o in stack)
            {
				stack.Remove(o);
            }
        }

	}


}
