using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostWithSemaphore
{
    public class Clerk
    {
        public int ID { get; private set; }
        private static int lastID = 1;
        private int servedClients = 0;
        private volatile bool isFree = true; 
        public Clerk()
        {
            ID = lastID++;
        }

        public void Serve(Client c)
        {
            c.taskToDo(this);
            lock (this)
            {
                servedClients++;
            }
            freeClerk();
        }

        public int InfoAboutWorkDone()
        {
            Console.WriteLine("Okienko " + ID +
            " Obsłużyło " + servedClients +
            " Klientów");
            return servedClients;
        }

        public bool CanApproach()
        {
            lock (this)
            {
                if (isFree)
                {
                    isFree = false;
                    return true;
                }
                return false;
            }
        }

        private void freeClerk()
        {
            lock (this)
            {
                isFree = true;
            }
        }
    }
}
