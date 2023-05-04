using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostWithSemaphore
{
    public class PostOffice
    {
        private Semaphore semaphore;
        private List<Clerk> clerks = new List<Clerk>();
        private volatile int clientsCount = 0;
        private Mutex countMutex = new Mutex();
        private volatile bool isClosed = false;

        public PostOffice(int NumberOfClerks)
        {
            semaphore = new Semaphore(NumberOfClerks, NumberOfClerks);
            for (int n = 0; n < NumberOfClerks; n++)
            {
                Clerk c = new Clerk();
                clerks.Add(c);
            }

        }

        public void ClientArrives(Client c)
        {
            lock (this)
            {
                if (isClosed)
                {
                    Console.WriteLine("Poczta zamknięta");
                    return;
                }
            }
            countMutex.WaitOne();
            clientsCount++;
            countMutex.ReleaseMutex();
            semaphore.WaitOne();
            Clerk clerk = selectClerk();
            clerk.Serve(c);
            semaphore.Release();
            countMutex.WaitOne(); 
            clientsCount--;
            if (clientsCount == 0)
            {
                Thread t = new Thread(new ThreadStart(this.closingPost));
                t.Start();
            }
            countMutex.ReleaseMutex();
            
        }

        private Clerk selectClerk()
        {
            Clerk c = null;
            foreach (Clerk clerk in clerks)
            {
                if (clerk.CanApproach())
                {
                    c = clerk;
                    break;
                }
            }
            return c;
        }

        private void closingPost()
        {
            //Wait maybe some clients will appear in near future
            Thread.Sleep(10);
            lock (this)
            {
                if (isClosed) return;
            }
            countMutex.WaitOne();
            if (clientsCount == 0)
            {
                Console.WriteLine("Zamykamy pocztę!!!!!");
                int total = 0;
                foreach (Clerk clerk in clerks)
                {
                    total += clerk.InfoAboutWorkDone();
                }
                Console.WriteLine("Razem obsłużono " + total + " klientów.");
                lock (this)
                {
                    isClosed = true;
                }
            }
            countMutex.ReleaseMutex();

        }

    }
}
