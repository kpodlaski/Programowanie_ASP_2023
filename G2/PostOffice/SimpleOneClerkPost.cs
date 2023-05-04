using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PostOffice { }
//{
//    class SimpleOneClerkPost
//    {
//        private List<Client> queue = new List<Client>();
//        private Clerk clerk = new Clerk();
//        private Random rand = new Random();
//        private List<int> served = new List<int>();
//        private int maxElements;

//        public SimpleOneClerkPost(int maxElements)
//        {
//            this.maxElements = maxElements;
//        }
//        private Client popFromQueue()
//        {
//            if (queue.Count > 0)
//            {
//                Client c = queue[queue.Count-1];
//                queue.Remove(c);
//                return c;
//            }
//            return null;
//        }

//        public void ServeClients()
//        {
//            while (true)
//            {
//                Client c = popFromQueue();
//                if (c == null)
//                {
//                    Console.WriteLine("Nie ma klientów w kolejce");
//                    break;
//                }
//                served.Add(c.ID);
//                clerk.Serve(c);
//            }
//            CheckServed();
//        }

//        public void FillQueue()
//        {
//            for (int i=0; i<maxElements; i++)
//            {
//                queue.Insert(0,new Client());
//            }
//            Console.WriteLine("All "+maxElements+" clients added to the list");
//        }

//        public void CheckServed()
//        {
//            for (int i=0; i<served.Count; i++)
//            {
//                if (i != served[i])
//                {
//                    Console.WriteLine("ERRRORR at " + i);
//                }
//            }
//            Console.WriteLine("All was OK");
//        }
//    }

