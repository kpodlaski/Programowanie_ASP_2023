using System;
using System.Collections.Generic;
using System.Text;

namespace PostOffice
{
    public interface MyQueue
    {
        public Client Pop();
        public void Push(Client c);

        public int Count();
    }
}
