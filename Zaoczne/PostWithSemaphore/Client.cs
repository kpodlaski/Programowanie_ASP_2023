using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostWithSemaphore
{
    public class Client
    {
        public int ID { get; private set; }
        static int lastId = 0;
        static Random rand = new Random();
        private PostOffice post;

        public Client(PostOffice post)
        {
            ID = lastId++;
            this.post = post;
        }

        public void taskToDo(Clerk c)
        {
            //Console.WriteLine(String.Format(
            // "Klient {0}: Podchodzę do okienka {1}", 
            // ID, c.ID));
            Thread.Sleep(rand.Next(1));
            Console.WriteLine(String.Format("Klient {0}: Odchodzę od okienka {1}", ID, c.ID));

        }

        public void GoToPostOffice()
        {
            post.ClientArrives(this);
        }
    }
}
