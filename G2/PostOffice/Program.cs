using System;
using System.Collections.Generic;
using System.Threading;

namespace PostOffice
{
    class Program
    {
        static List<Clerk> clercs = new List<Clerk>();

        static void Main(string[] args)
        {
            int NUMBER_OF_CLERCS = 10;
            Barrier barrier = new Barrier(NUMBER_OF_CLERCS, (a) => { Console.WriteLine("Zamykamy Pocztę"); });
            for ( int n=0; n<1000; n++)
            {
                q.Push(new Client());
            }
            for (int n=0; n<NUMBER_OF_CLERCS; n++)
            {
                Clerk c = new Clerk(q, barrier);
                clercs.Add(c);
                
            }
            Console.WriteLine("Koniec programu!!!!");
        }

        public static void DoWhenFinished()
        {
            foreach (Clerk c  in clercs)
            {
                c.InfoAboutWorkDone();
            }
        }
    }
}
