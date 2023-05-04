using System;
using System.Threading;

namespace PostWithSemaphore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Open Post");
            
            int NUMBER_OF_CLIENTS = 100;
            PostOffice post = new PostOffice(3);
            for (int i=0; i<NUMBER_OF_CLIENTS; i++)
            {
                Client c = new Client(post);
                Thread t = new Thread(new ThreadStart(c.GoToPostOffice));
                t.Start();
            }

            NUMBER_OF_CLIENTS += 20;
            for (int i = 0; i < 20; i++)
            {
                Client c = new Client(post);
                Thread t = new Thread(new ThreadStart(c.GoToPostOffice));
                t.Start();
            }
        }
    }
}
