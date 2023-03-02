using System;
using System.Collections.Generic;

namespace PostOffice
{
    public class Clerk
    {
        public int ID { get; private set; }
        private static int lastID=1;
        private MyQueue q;
        private int servedClients = 0;
        public Clerk(MyQueue queue)
        {
            ID = lastID++;
            q = queue;
        }

        public void Serve(Client c)
        {
            c.taskToDo(this);
        }

        public void Work()
        {
            while (q.Count() > 0)
            {
                Client c = q.Pop();
                c.taskToDo(this);
                servedClients++;
            }
            Console.WriteLine("Okienko " + ID + 
            " Obsłużyło " + servedClients + 
            " Klientów");

        }

    }
}