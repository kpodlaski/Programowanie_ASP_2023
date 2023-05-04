using System;
using System.Collections.Generic;
using System.Threading;

namespace PostOffice
{
    public class Clerk
    {
        public int ID { get; private set; }
        private static int lastID=1;
        private MyQueue q;
        private int servedClients = 0;
        private Barrier barrier;
        public Clerk(MyQueue queue, Barrier b)
        {
            ID = lastID++;
            q = queue;
            this.barrier = b;
        }

        public void Serve(Client c)
        {
            c.taskToDo(this);

        }

        public void Work()
        {
            while (true)
            {
                Client c;
                lock (q)
                {
                    if (q.Count() > 0) c = q.Pop();
                    else break;
                }
                Serve(c);
                servedClients++;
            }
            barrier.SignalAndWait();
            InfoAboutWorkDone();

        }

        public void InfoAboutWorkDone()
        {
            Console.WriteLine("Okienko " + ID +
            " Obsłużyło " + servedClients +
            " Klientów");
        }
    }
}