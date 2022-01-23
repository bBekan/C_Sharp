using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal static class Stopwatch
    {
        private static bool started = false;
        private static DateTime startTime;

        public static void Start()
        {
            if (!started)
            {
                started = true;
                startTime = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("You have to stop the stopwatch before starting it again!");
            }
        }
        public static void Stop()
        {
            if (!started)
            {
                Console.WriteLine("You have to start the stopwatch first");
            }
            else
            {
                Console.WriteLine("{0} seconds elapsed since start", (DateTime.Now - startTime).TotalSeconds);
                started = false;
            }
        }
    }
}
