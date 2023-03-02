using System;
using System.Collections.Generic;
using System.Threading;

namespace PostOffice
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int NUMBER_OF_CLERCS = 1;
            MyQueue q = new PostQueue();
            for ( int n=0; n<100; n++)
            {
                q.Push(new Client());
            }
            for (int n=0; n<NUMBER_OF_CLERCS; n++)
            {
                Clerk c = new Clerk(q);
                Thread t = new Thread(
                    new ThreadStart(c.Work));
                t.Start();
            }
            Console.WriteLine("Koniec programu!!!!");
        }
    }
}
