using System;
using System.Collections.Generic;
using System.Text;

namespace PostOffice
{
    class PostQueue: MyQueue
    {
        private List<Client> q = new List<Client>();

        public int Count()
        {
            return q.Count;
        }

        public Client Pop()
        {
            Client c;
            c = q[0];
            q.Remove(c);
            return c;
        }

        public void Push(Client c)
        {
            q.Add(c);
        }
    }
}
