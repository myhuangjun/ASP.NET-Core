using Common;
using System;

namespace CoreProject_01
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonStart start = new CommonStart();
            for (int i = 0; i < 10; i++)
            {
                start.Start();
            }
            Console.ReadKey();
        }
    }
}
