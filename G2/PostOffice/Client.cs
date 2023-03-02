using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PostOffice
{
    public class Client
    {
        public int ID { get; private set; } 
        static int lastId = 0;
        static Random rand = new Random();

        public Client()
        {
            ID = lastId++;
        }

        public void taskToDo(Clerk c)
        {
            Console.WriteLine(String.Format(
             "Klient {0}: Podchodzę do okienka {1}", 
             ID, c.ID));
            Thread.Sleep(rand.Next(10));
            Console.WriteLine(String.Format("Klient {0}: Odchodzę od okienka {1}", ID, c.ID));

        }

    }
}
