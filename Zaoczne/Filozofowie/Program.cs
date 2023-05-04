using System;
using System.Threading;

namespace Filozofowie
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5;
            Console.WriteLine("Creating Commune");
            Cutlery[] cutlery = new Cutlery[N+1];
            Philosopher[] philosopher = new Philosopher[N]; 
            for (int i=0; i<N; i++)
            {
                cutlery[i] = new Cutlery();
            }
            cutlery[cutlery.Length - 1] = cutlery[0];
            for (int i = 0; i < N; i++)
            {
                philosopher[i] = new Philosopher(cutlery[i], cutlery[i + 1]);
            }
            for (int i=0; i<N; i++)
            {
                Thread th = new Thread(new ThreadStart(philosopher[i].Life));
                th.Start();
            }

        }
    }
}
